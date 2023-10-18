using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class WorkflowStatusRequest
    {
		[Required]
		public bool Active { get; set; }
		[Required]
		public string Name { get; set; }

    }
}

