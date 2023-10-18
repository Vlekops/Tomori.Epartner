using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class RolePermissionRequest
    {
		[Required]
		public Guid IdPermission { get; set; }
		[Required]
		public string IdRole { get; set; }

    }
}

