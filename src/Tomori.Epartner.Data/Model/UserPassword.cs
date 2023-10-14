using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class UserPassword : IEntity
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public string Password { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
