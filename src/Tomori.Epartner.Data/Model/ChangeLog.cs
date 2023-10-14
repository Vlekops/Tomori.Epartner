using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class ChangeLog : IEntity
    {
        public ChangeLog()
        {
            ChangeLogProperty = new HashSet<ChangeLogProperty>();
        }

        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public string Tipe { get; set; }
        public string TableName { get; set; }
        public string PrimaryKey { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<ChangeLogProperty> ChangeLogProperty { get; set; }
    }
}
