using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class ChangeLogProperty : IEntity
    {
        public Guid Id { get; set; }
        public Guid IdChangeLog { get; set; }
        public string Property { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }

        public virtual ChangeLog IdChangeLogNavigation { get; set; }
    }
}
