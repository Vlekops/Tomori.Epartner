using Azure.Core;
using DocumentFormat.OpenXml.Office2016.Excel;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Tomori.Epartner.Core.Attributes;
using Tomori.Epartner.Core.Config.Query;
using Tomori.Epartner.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Vleko.DAL.Interface;
using Vleko.Result;

namespace Tomori.Epartner.Core.Helper
{
    public interface ITokenHelper
    {
        Task<ObjectResponse<TokenObject>> GenerateToken(TokenUserObject request);
        ObjectResponse<TokenObject> DecodeToken(string token);
    }
    public class TokenHelper : ITokenHelper
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly ApplicationConfig _config;
        public TokenHelper(
            ILogger<TokenHelper> logger,
            IMediator mediator,
            IOptions<ApplicationConfig> config
            )
        {
            _logger = logger;
            _mediator = mediator;
            _config = config.Value;
        }
        public async Task<ObjectResponse<TokenObject>> GenerateToken(TokenUserObject request)
        {
            ObjectResponse<TokenObject> result = new ObjectResponse<TokenObject>();
            try
            {
                var refresh_token = Guid.NewGuid().ToString();
                var token_handler = new JwtSecurityTokenHandler();
                var claims = new List<Claim> {
                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                new Claim(JwtRegisteredClaimNames.Sub, request.Id.ToString()),
                                new Claim(JwtRegisteredClaimNames.UniqueName, request.Username),
                                new Claim(JwtRegisteredClaimNames.GivenName, request.FullName),
                                new Claim(ClaimTypes.Email, request.Mail),
                                new Claim(ClaimTypes.MobilePhone, request.Phone ?? ""),
                                new Claim("photo_url", request.PhotoUrl ?? ""),
                                new Claim("token" , refresh_token)
                            };


                var setting = await _mediator.Send(new GetSettingConfigRequest());
                var key = Encoding.ASCII.GetBytes(_config.SecretKey);
                DateTime expired = DateTime.UtcNow.AddMinutes(setting.Data.ExpireSessionTime);
                var token = new JwtSecurityToken(issuer: _config.Issuer,
                                audience: _config.Audience,
                                claims: claims,
                                expires: expired,
                                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                            );

                result.Data = new TokenObject()
                {
                    ExpiredAt = expired,
                    RefreshToken = refresh_token,
                    RawToken = new JwtSecurityTokenHandler().WriteToken(token),
                    User = request
                };
                result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Generate Token", request);
                result.Error("Failed Generate Token", ex.Message);
            }
            return result;
        }
        public ObjectResponse<TokenObject> DecodeToken(string token)
        {
            ObjectResponse<TokenObject> result = new ObjectResponse<TokenObject>();
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var identity = handler.ReadJwtToken(token);

                if (identity.Claims != null && identity.Claims.Count() > 0)
                {
                    result.Data = new TokenObject();
                    var token_exp = identity.Claims.FirstOrDefault(claim => claim.Type.Equals("exp")).Value;
                    var ticks = long.Parse(token_exp);
                    result.Data.RawToken = token;
                    result.Data.RefreshToken = identity.Claims.FirstOrDefault(x => x.Type == "token")?.Value;
                    result.Data.ExpiredAt = DateTimeOffset.FromUnixTimeSeconds(ticks).UtcDateTime;
                    result.Data.User = new TokenUserObject()
                    {
                        Id = Guid.Parse(identity.Claims.FirstOrDefault(x => x.Type == "sub")?.Value),
                        Username = identity.Claims.FirstOrDefault(x => x.Type == "unique_name")?.Value,
                        FullName = identity.Claims.FirstOrDefault(x => x.Type == "given_name")?.Value,
                        Mail = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
                        Phone = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.MobilePhone)?.Value,
                        PhotoUrl = identity.Claims.FirstOrDefault(x => x.Type == "photo_url")?.Value
                    };
                    result.OK();
                }
                else
                    result.BadRequest("Not Valid JWT");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Decode Token", token);
                result.Error(ex.Message, ex.StackTrace);
            }
            return result;
        }
    }
}
