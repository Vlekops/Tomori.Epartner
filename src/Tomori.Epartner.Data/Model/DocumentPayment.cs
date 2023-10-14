using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class DocumentPayment : IEntity
    {
        public Guid Id { get; set; }
        public string ProgramDana { get; set; }
        public string MasterValueCode { get; set; }
        public string MasterValueText { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Sort { get; set; }
        public bool IsMandatory { get; set; }
        public long FileMaxSize { get; set; }
        public string FileExtension { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
