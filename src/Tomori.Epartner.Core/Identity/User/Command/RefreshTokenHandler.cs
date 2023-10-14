using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using Vleko.Result;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Core;
using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Data;

namespace Tomori.Epartner.Core.Identity.User.Command
{

    #region Request
    public class RefreshTokenRequest : IRequest<ObjectResponse<TokenObject>>
    {
        [Required]
        public string Token { get; set; }
    }
    #endregion

    internal class RefreshTokenHandler : IRequestHandler<RefreshTokenRequest, ObjectResponse<TokenObject>>
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IGeneralHelper _helper;
        private readonly ITokenHelper _token;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public RefreshTokenHandler(
            ILogger<RefreshTokenHandler> logger,
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
        public async Task<ObjectResponse<TokenObject>> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<TokenObject> result = new ObjectResponse<TokenObject>();
            try
            {
                var user = await _context.Single(_context.Entity<Tomori.Epartner.Data.Model.User>().Where(d => d.Token == request.Token));
                if (user != null)
                {
                    user.UpdateDate = DateTime.Now;
                    user.UpdateBy = user.Username;
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
                _logger.LogError(ex, "Failed Refresh Token", request);
                result.Error("Failed Refresh Token", ex.Message);
            }
            return result;
        }
    }
}

