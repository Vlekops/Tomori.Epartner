using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class Page : IEntity
    {
        public Page()
        {
            InverseIdParentNavigation = new HashSet<Page>();
            PagePermission = new HashSet<PagePermission>();
        }

        public Guid Id { get; set; }
        public Guid? IdParent { get; set; }
        public string Section { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Navigation { get; set; }
        public string Icon { get; set; }
        public int Sort { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Page IdParentNavigation { get; set; }
        public virtual ICollection<Page> InverseIdParentNavigation { get; set; }
        public virtual ICollection<PagePermission> PagePermission { get; set; }
    }
}
