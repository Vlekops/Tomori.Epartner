using AutoMapper;
using MediatR;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Vleko.Result;
using Tomori.Epartner.Core.Helper;
using Microsoft.Extensions.Caching.Memory;
using Tomori.Epartner.Data;
using Vleko.DAL.Interface;
//using Tomori.Epartner.Core.Log.Command;
using Tomori.Epartner.Core.Attributes;
using Tomori.Epartner.Core.Config.Query;

namespace Tomori.Epartner.Core.Identity.User.Command
{

    #region Request
    public class LoginRequest : IRequest<ObjectResponse<TokenObject>>
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
    #endregion

    internal class LoginUserHandler : IRequestHandler<LoginRequest, ObjectResponse<TokenObject>>
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IGeneralHelper _helper;
        private readonly ITokenHelper _token;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public LoginUserHandler(
            ILogger<LoginUserHandler> logger,
            IMediator mediator,
            IGeneralHelper helper,
            ITokenHelper token,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mediator = mediator;
            _helper = helper;
            _token = token;
            _context = context;
        }
        public async Task<ObjectResponse<TokenObject>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<TokenObject> result = new ObjectResponse<TokenObject>();
            try
            {
                string _hash = _helper.PasswordEncrypt(request.Password);
                var user = await _context.Entity<Data.Model.User>()
                            .Where(d => d.Username.ToLower() == request.Username.ToLower()).FirstOrDefaultAsync();
                if (user != null)
                {
                    if (!user.Active)
                    {
                        result.Forbidden($"User not active please call administrator for verified user!");
                        return result;
                    }
                    if (user.IsLockout)
                    {
                        result.Forbidden($"User has been Locked! call administrator for unlock!");
                        return result;
                    }
                    if (user.ExpiredUser.HasValue && DateTime.Now>user.ExpiredUser.Value)
                    {
                        result.Forbidden($"User has been Expired! call administrator if you need access!");
                        return result;
                    }
                    var config = await _mediator.Send(new GetSettingConfigRequest());
                    if (user.Password != _hash)
                    {
                        result.Forbidden($"Failed login please check again your password!");
                        if(config.Data.MaxLoginRetry>0)
                        {
                            user.AccessFailedCount++;
                            if (user.AccessFailedCount > config.Data.MaxLoginRetry)
                            {
                                user.IsLockout = true;
                                user.UpdateBy = user.Username;
                                user.UpdateDate = DateTime.Now;
                                await _context.UpdateSave(user);
                                result.Forbidden($"User has been Locked call administrator for unlock!");
                            }
                            else
                            {
                                await _context.UpdateSave(user);
                                result.Forbidden($"Failed login please check again your password!{Environment.NewLine} Retry {user.AccessFailedCount} of {config.Data.MaxLoginRetry}");
                            }
                        }
                        return result;
                    }
                    user.AccessFailedCount = 0;
                    user.IsLockout = false;
                    user.UpdateDate = DateTime.Now;
                    user.UpdateBy = $"{user.Username}";
                   
                    var generateToken = await _token.GenerateToken(new TokenUserObject()
                    {
                        Id = user.Id,
                        Username = user.Username,
                        FullName = user.Fullname,
                        Mail = user.Mail,
                        Phone = user.PhoneNumber,
                        PhotoUrl = user.PhotoUrl
                    });
                    if (generateToken.Succeeded)
                    {
                        result.Data = generateToken.Data;
                        user.Token = result.Data.RefreshToken;

                        var update = await _context.UpdateSave(user);
                        if (update.Success)
                            result.OK();
                        else
                            result.BadRequest(update.Message);
                    }
                    else
                        result = generateToken;
                }
                else
                    result.NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Login User", request);
                result.Error("Failed Add User", ex.Message);
            }
            return result;
        }
    }
}

