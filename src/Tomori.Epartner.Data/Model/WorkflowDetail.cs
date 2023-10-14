using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class WorkflowDetail : IEntity
    {
        public Guid Id { get; set; }
        public Guid IdWorkflow { get; set; }
        public int GroupNo { get; set; }
        public int StepNo { get; set; }
        public string StepName { get; set; }
        public Guid IdUser { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsReviewer { get; set; }
        public bool IsAdhoc { get; set; }
        public bool CanAdhoc { get; set; }
        public DateTime? AutoApproveExpired { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Workflow IdWorkflowNavigation { get; set; }
    }
}
