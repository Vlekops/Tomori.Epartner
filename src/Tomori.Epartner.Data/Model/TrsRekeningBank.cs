using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class TrsRekeningBank : IEntity
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public string PemegangRekening { get; set; }
        public string NoRekening { get; set; }
        public string NoRekeningFormat { get; set; }
        public string JenisMataUang { get; set; }
        public string NamaBank { get; set; }
        public string KantorCabang { get; set; }
        public string Negara { get; set; }
        public string FileSuratPernyataan { get; set; }
        public string FileSuratPernyataanId { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
