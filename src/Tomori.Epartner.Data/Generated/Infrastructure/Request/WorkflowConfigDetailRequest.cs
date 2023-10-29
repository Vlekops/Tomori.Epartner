using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class WorkflowConfigDetailRequest
    {
		public DateTime? AutoApprovedExpired { get; set; }
		[Required]
		public bool CanAdhoc { get; set; }
		[Required]
		public Guid IdUser { get; set; }
		[Required]
		public Guid IdWorkflowConfig { get; set; }
		[Required]
		public bool IsReviewer { get; set; }
		[Required]
		public string StepName { get; set; }
		[Required]
		public int StepNo { get; set; }

    }
}

