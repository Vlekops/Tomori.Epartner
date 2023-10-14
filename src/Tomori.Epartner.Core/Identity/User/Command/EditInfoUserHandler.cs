using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using Vleko.Result;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Data;
using Tomori.Epartner.Core.Request;
using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Core.Log.Command;

namespace Tomori.Epartner.Core.Identity.User.Command
{
    #region Request
    public class EditInfoUserMapping : Profile
    {
        public EditInfoUserMapping()
        {
            CreateMap<EditInfoUserRequest, UserRequest>().ReverseMap();
        }
    }
    public class EditInfoUserRequest : UserRequest, IRequest<StatusResponse>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public TokenUserObject Token { get; set; }
    }
    #endregion

    internal class EditInfoUserHandler : IRequestHandler<EditInfoUserRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IGeneralHelper _helper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public EditInfoUserHandler(
            ILogger<EditInfoUserHandler> logger,
            IMediator mediator,
            IGeneralHelper helper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mediator = mediator;
            _helper = helper;
            _context = context;
        }
        public async Task<StatusResponse> Handle(EditInfoUserRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var user = await _context.Entity<Data.Model.User>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (user != null)
                {
                    string mail = user.Mail;
                    if(user.Mail != request.Mail)
                    {
                        if (!_helper.ValidateMail(request.Mail.Trim()))
                        {
                            result.NotAcceptable($"Email {request.Mail} is not valid!");
                            return result;
                        }
                        mail = request.Mail;
                    }
                    var phone = user.PhoneNumber;
                    var phone_number = _helper.ValidatePhoneNumber(request.PhoneNumber);
                    if(!phone_number.Succeeded)
                    {
                        result.NotAcceptable($"Phone Number {request.PhoneNumber} is not valid!");
                        return result;
                    }
                    if (user.PhoneNumber != phone_number.Data)
                        phone = phone_number.Data;

                    user.Mail = mail;
                    user.PhotoUrl = request.PhotoUrl;
                    user.PhoneNumber = phone;
                    user.Fullname = request.Fullname;
                    user.UpdateBy = request.Token.Username;
                    user.UpdateDate = DateTime.Now;

                    var update = await _context.UpdateSave(user);
                    if (update.Success)
                    {
                        _ = Task.Run(() => _mediator.Send(new AddChangeLogRequest() { IdUser = request.Token.Id, ChangeLog = update.log }));
                        result.OK();
                    }
                    else
                        result.BadRequest(update.Message);

                    return result;
                }
                else
                    result.NotFound($"Id User {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Edit User", request);
                result.Error("Failed Edit User", ex.Message);
            }
            return result;
        }
    }
}

