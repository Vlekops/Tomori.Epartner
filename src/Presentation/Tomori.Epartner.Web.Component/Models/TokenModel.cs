using Vleko.Result;

namespace Tomori.Epartner.Web.Component.Models
{
    public class TokenModel
    {
        public TokenUserModel User { get; set; }
        public DateTime ExpiredAt { get; set; }
        public string RawToken { get; set; }
        public string RefreshToken { get; set; }
        public string BaseApiUrl { get; set; }
    }
    public class TokenUserModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string PhotoUrl { get; set; }
    }
}
