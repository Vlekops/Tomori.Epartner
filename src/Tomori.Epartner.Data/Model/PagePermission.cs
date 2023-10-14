using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class PagePermission : IEntity
    {
        public PagePermission()
        {
            RolePermission = new HashSet<RolePermission>();
        }

        public Guid Id { get; set; }
        public Guid IdPage { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Page IdPageNavigation { get; set; }
        public virtual ICollection<RolePermission> RolePermission { get; set; }
    }
}
