using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class WorkflowConfigDetail : IEntity
    {
        public Guid Id { get; set; }
        public Guid IdWorkflowConfig { get; set; }
        public int StepNo { get; set; }
        public string StepName { get; set; }
        public Guid IdUser { get; set; }
        public bool IsReviewer { get; set; }
        public bool CanAdhoc { get; set; }
        public DateTime? AutoApprovedExpired { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual User IdUserNavigation { get; set; }
        public virtual WorkflowConfig IdWorkflowConfigNavigation { get; set; }
    }
}
