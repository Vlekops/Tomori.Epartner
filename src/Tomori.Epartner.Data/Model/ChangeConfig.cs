using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class ChangeConfig : IEntity
    {
        public Guid Id { get; set; }
        public string Modul { get; set; }
        public string Field { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
