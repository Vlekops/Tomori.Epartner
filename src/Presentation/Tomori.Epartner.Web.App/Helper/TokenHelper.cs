using Tomori.Epartner.Web.Component.Models;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json;
using Tomori.Epartner.Web.Component.Services;

namespace Tomori.Epartner.Web.App.Helper
{
    public interface ITokenHelper
    {
        (ClaimsPrincipal principal, AuthenticationProperties properties) CreateToken(TokenModel request, SettingConfig config, CompanyConfig company);
        (bool Success, TokenModel Token, SettingConfig Config, CompanyConfig Company) DecodeToken(HttpContext context);
    }
    public class TokenHelper : ITokenHelper
    {
        private readonly ILogger _logger;
        private string API_URL;
        public TokenHelper(IConfiguration configuration,
            ILogger<TokenHelper> logger
            )
        {
            API_URL = configuration.GetValue<string>("APIUrl");
            _logger = logger;
        }

        #region Create
        public (ClaimsPrincipal principal, AuthenticationProperties properties) CreateToken(TokenModel request, SettingConfig config, CompanyConfig company)
        {
            try
            {
                var claims = new List<Claim>()
                    {
                        new Claim("user_id", request.User.Id.ToString()),
                        new Claim("username", request.User.Username),
                        new Claim("given_name", request.User.FullName),
                        new Claim(ClaimTypes.Email, request.User.Mail),
                        new Claim(ClaimTypes.MobilePhone, request.User.Phone),
                        new Claim("token", request.RawToken),
                        new Claim("refresh",request.RefreshToken),
                        new Claim("setting",JsonConvert.SerializeObject(config)),
                        new Claim("company",JsonConvert.SerializeObject(company))
                    };
                if (!string.IsNullOrWhiteSpace(request.User.PhotoUrl))
                    claims.Add(new Claim("photo_url", request.User.PhotoUrl));

                var identity = new ClaimsIdentity(claims, HelperClient.AUTHENTICATION_SCHEMA);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties
                {
                    IssuedUtc = DateTime.Now.ToUniversalTime(),
                    ExpiresUtc = request.ExpiredAt
                };
                return (principal, properties);
            }
            catch (Exception)
            {
                return (null, null);
            }
        }
        #endregion

        #region Decode
        public (bool Success, TokenModel Token, SettingConfig Config, CompanyConfig Company) DecodeToken(HttpContext context)
        {
            try
            {
                var claims = context.User.Identities?.First().Claims.ToList();
                if (claims != null && claims.Count() > 0)
                {
                    var token = new TokenModel()
                    {
                        RawToken = claims?.FirstOrDefault(x => x.Type.Equals("token"))?.Value,
                        RefreshToken = claims?.FirstOrDefault(x => x.Type.Equals("refresh"))?.Value,
                        User = new TokenUserModel()
                        {
                            Id = Guid.Parse(claims?.FirstOrDefault(x => x.Type.Equals("user_id"))?.Value),
                            FullName = claims?.FirstOrDefault(x => x.Type.Equals("given_name"))?.Value,
                            Username = claims?.FirstOrDefault(x => x.Type.Equals("username"))?.Value,
                            Mail = claims?.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Email))?.Value,
                            Phone = claims?.FirstOrDefault(x => x.Type.Equals(ClaimTypes.MobilePhone))?.Value,
                            PhotoUrl = claims?.FirstOrDefault(x => x.Type.Equals("photo_url"))?.Value
                        },
                        BaseApiUrl = API_URL
                    };
                    var config = JsonConvert.DeserializeObject<SettingConfig>(claims?.FirstOrDefault(x => x.Type.Equals("setting"))?.Value);
                    var company = JsonConvert.DeserializeObject<CompanyConfig>(claims?.FirstOrDefault(x => x.Type.Equals("company"))?.Value);
                    return (true, token, config, company);
                }
                else
                    return (false, null, null, null);
            }
            catch (Exception)
            {
                return (false, null, null, null);
            }
        }
        #endregion
    }
}