using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class NotificationRequest
    {
		[Required]
		public string Description { get; set; }
		[Required]
		public Guid IdUser { get; set; }
		[Required]
		public bool IsOpen { get; set; }
		[Required]
		public string Navigation { get; set; }
		[Required]
		public string Subject { get; set; }

    }
}

