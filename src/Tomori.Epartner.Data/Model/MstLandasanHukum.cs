using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class MstLandasanHukum : IEntity
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public string JenisAkta { get; set; }
        public string NoAkta { get; set; }
        public string NamaNotaris { get; set; }
        public string NamaSkMenteri { get; set; }
        public string FileLandasanHukum { get; set; }
        public Guid? FileLandasanHukumId { get; set; }
        public DateTime TglAkta { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
