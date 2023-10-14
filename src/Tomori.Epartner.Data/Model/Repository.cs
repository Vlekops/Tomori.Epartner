using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class Repository : IEntity
    {
        public Repository()
        {
            WorkflowAttachment = new HashSet<WorkflowAttachment>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Modul { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string Extension { get; set; }
        public string Base64 { get; set; }
        public string MimeType { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<WorkflowAttachment> WorkflowAttachment { get; set; }
    }
}
