using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class WorkflowStatus : IEntity
    {
        public WorkflowStatus()
        {
            WorkflowLog = new HashSet<WorkflowLog>();
        }

        public short Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<WorkflowLog> WorkflowLog { get; set; }
    }
}
