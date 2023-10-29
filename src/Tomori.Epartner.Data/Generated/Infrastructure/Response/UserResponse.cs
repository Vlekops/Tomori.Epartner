using System;
using System.Linq;
using System.Text;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class UserResponse
    {
		public Guid Id { get; set; }
		public int AccessFailedCount { get; set; }
		public bool Active { get; set; }
		public string CreateBy { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime? ExpiredPassword { get; set; }
		public DateTime? ExpiredUser { get; set; }
		public string Fullname { get; set; }
		public bool IsLockout { get; set; }
		public DateTime? LastChangePassword { get; set; }
		public DateTime? LastLogin { get; set; }
		public string Mail { get; set; }
		public string Password { get; set; }
		public string PhoneNumber { get; set; }
		public string PhotoUrl { get; set; }
		public string Token { get; set; }
		public string UpdateBy { get; set; }
		public DateTime? UpdateDate { get; set; }
		public string Username { get; set; }

    }
}

