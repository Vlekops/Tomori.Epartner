using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class UserPasswordRequest
    {
		[Required]
		public Guid IdUser { get; set; }
		[Required]
		public string Password { get; set; }

    }
}

