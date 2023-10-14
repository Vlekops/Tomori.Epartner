using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class Workflow : IEntity
    {
        public Workflow()
        {
            WorkflowAttachment = new HashSet<WorkflowAttachment>();
            WorkflowDetail = new HashSet<WorkflowDetail>();
            WorkflowLog = new HashSet<WorkflowLog>();
        }

        public Guid Id { get; set; }
        public string DocumentNo { get; set; }
        public string WorkflowCode { get; set; }
        public string Code { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public int GroupNo { get; set; }
        public int StepNo { get; set; }
        public string DataWorkflow { get; set; }
        public string CallbackUrl { get; set; }
        public string NavigationUrl { get; set; }
        public Guid IdUserRequester { get; set; }
        public string FullnameRequester { get; set; }
        public string EmailRequester { get; set; }
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<WorkflowAttachment> WorkflowAttachment { get; set; }
        public virtual ICollection<WorkflowDetail> WorkflowDetail { get; set; }
        public virtual ICollection<WorkflowLog> WorkflowLog { get; set; }
    }
}
