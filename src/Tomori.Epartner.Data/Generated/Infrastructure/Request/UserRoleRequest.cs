using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class UserRoleRequest
    {
		[Required]
		public string IdRole { get; set; }
		[Required]
		public Guid IdUser { get; set; }

    }
}

