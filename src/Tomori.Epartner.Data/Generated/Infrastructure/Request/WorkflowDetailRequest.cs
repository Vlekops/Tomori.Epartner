using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class WorkflowDetailRequest
    {
		public DateTime? AutoApprovedExpired { get; set; }
		[Required]
		public bool CanAdhoc { get; set; }
		public string Email { get; set; }
		[Required]
		public string FullName { get; set; }
		[Required]
		public int GroupNo { get; set; }
		[Required]
		public Guid IdUser { get; set; }
		[Required]
		public Guid IdWorkflow { get; set; }
		[Required]
		public bool IsAdhoc { get; set; }
		[Required]
		public bool IsReviewer { get; set; }
		[Required]
		public string StepName { get; set; }
		[Required]
		public int StepNo { get; set; }

    }
}

