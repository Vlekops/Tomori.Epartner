using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class UserActivity : IEntity
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public string PageName { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
