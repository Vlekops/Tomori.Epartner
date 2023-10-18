//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
// </auto-generated>
//------------------------------------------------------------------------------

using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Data;
using Vleko.Result;
using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Core.Request;
using Tomori.Epartner.Core.Log.Command;

namespace Tomori.Epartner.Core.UserDelegate.Command
{

    #region Request
    public class AddUserDelegateMapping: Profile
    {
        public AddUserDelegateMapping()
        {
            CreateMap<AddUserDelegateRequest, UserDelegateRequest>().ReverseMap();
        }
    }
    public class AddUserDelegateRequest :UserDelegateRequest, IMapRequest<Tomori.Epartner.Data.Model.UserDelegate, AddUserDelegateRequest>,IRequest<StatusResponse>
    {
        [Required]
        public TokenUserObject Token { get; set; }
        public void Mapping(IMappingExpression<AddUserDelegateRequest, Tomori.Epartner.Data.Model.UserDelegate> map)
        {
            //use this for mapping
            //map.ForMember(d => d.EF_COLUMN, opt => opt.MapFrom(s => s.Object));
        }
    }
    #endregion

    internal class AddUserDelegateHandler : IRequestHandler<AddUserDelegateRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public AddUserDelegateHandler(
            ILogger<AddUserDelegateHandler> logger,
            IMapper mapper,
            IMediator mediator,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            _context = context;
        }
        public async Task<StatusResponse> Handle(AddUserDelegateRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var data = _mapper.Map<Tomori.Epartner.Data.Model.UserDelegate>(request);
                data.CreateBy = request.Token.Username;
                data.CreateDate = DateTime.Now;
                var add = await _context.AddSave(data);
                if (add.Success)
                {
                    _ = Task.Run(() => _mediator.Send(new AddChangeLogRequest() { IdUser = request.Token.Id, ChangeLog = add.log }));
                    result.OK();
                }
                else
                    result.BadRequest(add.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Add UserDelegate", request);
                result.Error("Failed Add UserDelegate", ex.Message);
            }
            return result;
        }
    }
}

