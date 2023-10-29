using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class WorkflowLog : IEntity
    {
        public Guid Id { get; set; }
        public Guid IdWorkflow { get; set; }
        public int GroupNo { get; set; }
        public int StepNo { get; set; }
        public string StepName { get; set; }
        public Guid IdUser { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public bool IsReviewer { get; set; }
        public bool IsAdhoc { get; set; }
        public short IdWorkflowStatus { get; set; }
        public string StatusDescription { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Workflow IdWorkflowNavigation { get; set; }
        public virtual WorkflowStatus IdWorkflowStatusNavigation { get; set; }
    }
}
