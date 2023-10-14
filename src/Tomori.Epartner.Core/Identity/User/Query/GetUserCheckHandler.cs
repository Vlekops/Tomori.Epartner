using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using Vleko.Result;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Data;
using Tomori.Epartner.Core.Response;
using Tomori.Epartner.Core.Config.Query;
using Tomori.Epartner.Core.Helper;

namespace Tomori.Epartner.Core.Identity.User.Query
{

    public class GetUserCheckRequest : IRequest<ObjectResponse<CheckUserResponse>>
    {
        [Required]
        public Guid UserId { get; set; }
    }
    internal class GetUserCheckHandler : IRequestHandler<GetUserCheckRequest, ObjectResponse<CheckUserResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IGeneralHelper _helper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetUserCheckHandler(
            ILogger<GetUserCheckHandler> logger,
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
        public async Task<ObjectResponse<CheckUserResponse>> Handle(GetUserCheckRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<CheckUserResponse> result = new ObjectResponse<CheckUserResponse>();
            try
            {
                var user = await _context.Entity<Data.Model.User>().Where(d => d.Id == request.UserId).FirstOrDefaultAsync();
                if (user != null)
                {
                    result.Data = new CheckUserResponse()
                    {
                        Code = 0,
                        Message = "OK"
                    };
                    var config = await _mediator.Send(new GetSettingConfigRequest());

                    string _hash_default_password = _helper.PasswordEncrypt(config.Data.DefaultPassword);
                    if (user.Password == _hash_default_password)
                    {
                        result.Data.Code = 1;
                        result.Data.Message = "Password masih default, mohon ganti password dengan klik button change password!";
                    }
                    if (user.ExpiredPassword.HasValue && DateTime.Now > user.ExpiredPassword.Value)
                    {
                        result.Data.Code = 1;
                        result.Data.Message = $"Password telah kadaluarsa, batas kadaluarsa password {config.Data.PasswordExpiredDays} hari, mohon ganti password dengan klik button change password!";
                    }

                    result.OK();
                }
                else
                    result.NotFound($"Id User {request.UserId} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Check User", request.UserId);
                result.Error("Failed Get Check User", ex.Message);
            }
            return result;
        }
    }
}

