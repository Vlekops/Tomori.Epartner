using Vleko.Result;

namespace Tomori.Epartner.Core.Attributes
{
    public class TokenObject
    {
        public TokenUserObject User { get; set; }
        public DateTime ExpiredAt { get; set; }
        public string RawToken { get; set; }
        public string RefreshToken { get; set; }
    }
    public class TokenUserObject
    {
        public Guid Id { get; set; }
        public ReferensiStringObject Role { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
    }
}
