using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class UserRequest
    {
		[Required]
		public int AccessFailedCount { get; set; }
		[Required]
		public bool Active { get; set; }
		public DateTime? ExpiredPassword { get; set; }
		public DateTime? ExpiredUser { get; set; }
		[Required]
		public string Fullname { get; set; }
		[Required]
		public bool IsLockout { get; set; }
		public DateTime? LastChangePassword { get; set; }
		public DateTime? LastLogin { get; set; }
		[Required]
		public string Mail { get; set; }
		[Required]
		public string Password { get; set; }
		[Required]
		public string PhoneNumber { get; set; }
		public string PhotoUrl { get; set; }
		public string Token { get; set; }
		[Required]
		public string Username { get; set; }

    }
}

