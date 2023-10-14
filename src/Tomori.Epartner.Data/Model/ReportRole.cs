using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class ReportRole : IEntity
    {
        public Guid Id { get; set; }
        public Guid IdReport { get; set; }
        public string IdRole { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Report IdReportNavigation { get; set; }
        public virtual Role IdRoleNavigation { get; set; }
    }
}
