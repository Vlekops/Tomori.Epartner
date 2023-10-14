using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class RolePermission : IEntity
    {
        public Guid Id { get; set; }
        public string IdRole { get; set; }
        public Guid IdPermission { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual PagePermission IdPermissionNavigation { get; set; }
        public virtual Role IdRoleNavigation { get; set; }
    }
}
