using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class ApiLog : IEntity
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public string Endpoint { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
