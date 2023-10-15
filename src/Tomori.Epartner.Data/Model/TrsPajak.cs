using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class TrsPajak : IEntity
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public string TipeDokumen { get; set; }
        public string NoDokumen { get; set; }
        public string FileDokumen { get; set; }
        public string Kondisi { get; set; }
        public string PeriodeAwal { get; set; }
        public string PeriodeAkhir { get; set; }
        public int? Tahun { get; set; }
        public Guid? FileDokumenId { get; set; }
        public DateTime? Tanggal { get; set; }
        public DateTime? TanggalAkhir { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
