using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class TrsIzinUsaha : IEntity
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public string JenisIzinUsaha { get; set; }
        public string Other { get; set; }
        public string BidangUsaha { get; set; }
        public string GolonganUsaha { get; set; }
        public string NoIzinUsaha { get; set; }
        public string InstansiPemberiIzin { get; set; }
        public string FileIzinUsaha { get; set; }
        public string TipeStp { get; set; }
        public string MerkStp { get; set; }
        public string PeringkatInspeksi { get; set; }
        public Guid? FileIzinUsahaId { get; set; }
        public string JenisMataUang { get; set; }
        public decimal? KekayaanBershi { get; set; }
        public DateTime MulaiBerlaku { get; set; }
        public DateTime AkhirBerlaku { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
