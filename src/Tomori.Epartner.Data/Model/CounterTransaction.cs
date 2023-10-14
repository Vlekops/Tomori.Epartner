using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class CounterTransaction : IEntity
    {
        public Guid Id { get; set; }
        public string Modul { get; set; }
        public int Counter { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
