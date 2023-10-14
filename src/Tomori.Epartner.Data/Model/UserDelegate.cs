using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class UserDelegate : IEntity
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdUserDelegate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual User IdUserDelegateNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
