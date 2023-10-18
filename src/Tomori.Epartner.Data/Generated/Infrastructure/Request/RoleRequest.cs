using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class RoleRequest
    {
		[Required]
		public string Id { get; set; }
		[Required]
		public bool Active { get; set; }
		[Required]
		public string Name { get; set; }

    }
}

