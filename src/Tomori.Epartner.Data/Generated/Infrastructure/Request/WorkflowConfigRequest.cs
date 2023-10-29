using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class WorkflowConfigRequest
    {
		[Required]
		public bool Active { get; set; }
		public string CallbackUrl { get; set; }
		[Required]
		public string Code { get; set; }
		[Required]
		public bool IsSequence { get; set; }
		[Required]
		public string Name { get; set; }
		public string NavigationUrl { get; set; }

    }
}

