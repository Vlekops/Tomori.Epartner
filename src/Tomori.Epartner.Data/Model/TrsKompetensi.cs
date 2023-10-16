using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class TrsKompetensi : IEntity
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public string BidangSubBidangCode { get; set; }
        public string BidangSubBidang { get; set; }
        public string Deskripsi { get; set; }
        public string Perusahaan { get; set; }
        public string NoKontrakPoso { get; set; }
        public string JenisMataUang { get; set; }
        public long? NilaiKontrakPoso { get; set; }
        public string ProgressKontrakPoso { get; set; }
        public string Document { get; set; }
        public string DocumentId { get; set; }
        public DateTime? TglKontrakPoso { get; set; }
        public DateTime? TglPenyelesaian { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
