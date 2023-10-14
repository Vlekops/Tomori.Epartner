using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class WorkflowConfig : IEntity
    {
        public WorkflowConfig()
        {
            WorkflowConfigDetail = new HashSet<WorkflowConfigDetail>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string CallbackUrl { get; set; }
        public string NavigationUrl { get; set; }
        public bool IsSequence { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<WorkflowConfigDetail> WorkflowConfigDetail { get; set; }
    }
}
