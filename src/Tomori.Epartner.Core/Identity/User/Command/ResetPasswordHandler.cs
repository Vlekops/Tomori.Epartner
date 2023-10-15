using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using Vleko.Result;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Data;
using Tomori.Epartner.Core.Helper;
//using Tomori.Epartner.Core.Log.Command;
using Microsoft.Extensions.Options;
using Tomori.Epartner.Core.Attributes;
using Tomori.Epartner.Core.Config.Query;

namespace Tomori.Epartner.Core.Identity.User.Command
{
    #region Request
    public class ResetPasswordRequest : IRequest<StatusResponse>
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public TokenUserObject Token { get; set; }
    }
    #endregion

    internal class ResetPasswordHandler : IRequestHandler<ResetPasswordRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IGeneralHelper _helper;
        private readonly IMediator _mediator;
        private readonly ApplicationConfig _config;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public ResetPasswordHandler(
            ILogger<ResetPasswordHandler> logger,
            IGeneralHelper helper,
            IMediator mediator,
            IOptions<ApplicationConfig> config,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _helper = helper;
            _mediator = mediator;
            _config = config.Value;
            _context = context;
        }
        public async Task<StatusResponse> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var user = await _context.Entity<Data.Model.User>().Where(d => d.Id == request.UserId).FirstOrDefaultAsync();
                if (user != null)
                {
                    var config = await _mediator.Send(new GetSettingConfigRequest());
                    string _hash_default_password = _helper.PasswordEncrypt(config.Data.DefaultPassword);
                    user.Password = _hash_default_password;
                    user.LastChangePassword = DateTime.Now;
                    user.UpdateBy = request.Token.Username;
                    user.UpdateDate = DateTime.Now;
                    var save = await _context.UpdateSave(user);
                    if (save.Success)
                    {
                        //_ = Task.Run(() => _mediator.Send(new AddChangeLogRequest() { IdUser = request.Token.Id, ChangeLog = save.log }));
                        result.OK();
                    }
                    else
                        result.BadRequest(save.Message);
                }
                else
                    result.NotFound("User Not Found!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Change Password", request);
                result.Error("Failed Change Password", ex.Message);
            }
            return result;
        }
    }
}

