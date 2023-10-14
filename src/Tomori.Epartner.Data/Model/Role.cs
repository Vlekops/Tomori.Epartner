using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class Role : IEntity
    {
        public Role()
        {
            ReportRole = new HashSet<ReportRole>();
            RolePermission = new HashSet<RolePermission>();
            UserRole = new HashSet<UserRole>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<ReportRole> ReportRole { get; set; }
        public virtual ICollection<RolePermission> RolePermission { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
