using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Data;
using Vleko.Result;
using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Core.Request;
using Hangfire.Common;
using Hangfire;
//using Tomori.Epartner.Core.Log.Command;
using Microsoft.EntityFrameworkCore;

namespace Tomori.Epartner.Core.Notification.Command
{
    #region Request
    public class AddNotificationMapping: Profile
    {
        public AddNotificationMapping()
        {
            CreateMap<AddNotificationRequest, NotificationRequest>().ReverseMap();
        }
    }
    public class AddNotificationRequest :NotificationRequest, IMapRequest<Data.Model.Notification, AddNotificationRequest>,IRequest<ObjectResponse<Guid>>
    {
        [Required]
        public TokenUserObject Token { get; set; }
        public void Mapping(IMappingExpression<AddNotificationRequest, Data.Model.Notification> map)
        {
            //use this for mapping
            //map.ForMember(d => d.EF_COLUMN, opt => opt.MapFrom(s => s.Object));
        }
    }
    #endregion

    internal class AddNotificationHandler : IRequestHandler<AddNotificationRequest, ObjectResponse<Guid>>
    {

        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IEmailHelper _mail;
        private readonly IBackgroundJobClient _job;
        private readonly IUnitOfWork<ApplicationDBContext> _context;

        public AddNotificationHandler(
            ILogger<AddNotificationHandler> logger,
            IMapper mapper,
            IMediator mediator,
            IEmailHelper mail,
            IBackgroundJobClient job,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            _mail = mail;
            _job = job;
            _context = context;
        }
        public async Task<ObjectResponse<Guid>> Handle(AddNotificationRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<Guid> result = new ObjectResponse<Guid>();
            try
            {
                var user = await _context.Entity<Data.Model.User>().Where(d => d.Id == request.IdUser).FirstOrDefaultAsync();
                if(user==null)
                {
                    result.NotFound($"User {request.IdUser} Tidak ditemukan!");
                    return result;
                }
                var data = _mapper.Map<Data.Model.Notification>(request);
                data.IsOpen = false;
                data.CreateBy = request.Token.Username;
                data.CreateDate = DateTime.Now;
                data.Id = Guid.NewGuid();
                var add = await _context.AddSave(data);
                if (add.Success)
                {
                    if (!string.IsNullOrWhiteSpace(user.Mail))
                    {
                        _job.Enqueue(() =>
                                        _mail.SendMail(user.Fullname,
                                            new List<string>() { user.Mail }, null,
                                            request.Subject,
                                            request.Description, null
                                        ));
                    }
                    ////_ = Task.Run(() => _mediator.Send(new AddChangeLogRequest() { IdUser = request.Token.Id, ChangeLog = add.log }));
                    result.Data = data.Id;
                    result.OK();

                    //#region Push notif
                    //_ = _mediator.Send(new PushNotifMainAppRequest
                    //{
                    //    IdUser = request.IdUser
                    //});
                    //#endregion
                }
                else
                    result.BadRequest(add.Message);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Add Notification", request);
                result.Error("Failed Add Notification", ex.Message);
            }
            return result;
        }
    }
}

