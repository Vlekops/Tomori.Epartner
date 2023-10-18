using System;
using System.Linq;
using System.Text;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class WorkflowConfigDetailResponse
    {
		public Guid Id { get; set; }
		public DateTime? AutoApprovedExpired { get; set; }
		public bool CanAdhoc { get; set; }
		public string CreateBy { get; set; }
		public DateTime CreateDate { get; set; }
		public Guid IdUser { get; set; }
		public Guid IdWorkflowConfig { get; set; }
		public bool IsReviewer { get; set; }
		public string StepName { get; set; }
		public int StepNo { get; set; }
		public string UpdateBy { get; set; }
		public DateTime? UpdateDate { get; set; }

    }
}

