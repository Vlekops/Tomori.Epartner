using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class VLandasanHukum : IEntity
    {
        public Guid Id { get; set; }
        public int CivdId { get; set; }
        public Guid? IdVendor { get; set; }
        public string JenisAkta { get; set; }
        public string NoAkta { get; set; }
        public string NamaNotaris { get; set; }
        public string NamaSkMenteri { get; set; }
        public string FileLandasanHukum { get; set; }
        public string FileLandasanHukumId { get; set; }
        public DateTime? TglAkta { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Vendor IdVendorNavigation { get; set; }
    }
}
