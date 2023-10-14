using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class WorkflowAttachment : IEntity
    {
        public Guid Id { get; set; }
        public Guid IdWorkflow { get; set; }
        public Guid IdRepository { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Repository IdRepositoryNavigation { get; set; }
        public virtual Workflow IdWorkflowNavigation { get; set; }
    }
}
