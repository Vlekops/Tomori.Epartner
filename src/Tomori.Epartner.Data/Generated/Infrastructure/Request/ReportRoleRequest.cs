using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class ReportRoleRequest
    {
		[Required]
		public Guid IdReport { get; set; }
		[Required]
		public string IdRole { get; set; }

    }
}

