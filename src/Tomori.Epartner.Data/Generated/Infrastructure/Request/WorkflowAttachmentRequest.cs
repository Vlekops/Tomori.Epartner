using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class WorkflowAttachmentRequest
    {
		[Required]
		public Guid IdRepository { get; set; }
		[Required]
		public Guid IdWorkflow { get; set; }

    }
}

