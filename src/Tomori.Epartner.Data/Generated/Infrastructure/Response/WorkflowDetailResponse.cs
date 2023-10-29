using System;
using System.Linq;
using System.Text;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class WorkflowDetailResponse
    {
		public Guid Id { get; set; }
		public DateTime? AutoApprovedExpired { get; set; }
		public bool CanAdhoc { get; set; }
		public string CreateBy { get; set; }
		public DateTime CreateDate { get; set; }
		public string Email { get; set; }
		public string FullName { get; set; }
		public int GroupNo { get; set; }
		public Guid IdUser { get; set; }
		public Guid IdWorkflow { get; set; }
		public bool IsAdhoc { get; set; }
		public bool IsReviewer { get; set; }
		public string StepName { get; set; }
		public int StepNo { get; set; }

    }
}

