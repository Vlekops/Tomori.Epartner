using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class PagePermissionRequest
    {
		[Required]
		public bool Active { get; set; }
		[Required]
		public Guid IdPage { get; set; }
		[Required]
		public string Name { get; set; }

    }
}

