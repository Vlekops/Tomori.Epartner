using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class Report : IEntity
    {
        public Report()
        {
            ReportRole = new HashSet<ReportRole>();
        }

        public Guid Id { get; set; }
        public string Modul { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Query { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<ReportRole> ReportRole { get; set; }
    }
}
