using System;
using System.Linq;
using System.Text;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class VendorPajakResponse
    {
		public Guid Id { get; set; }
		public int CivdId { get; set; }
		public DateTime? CompletedDate { get; set; }
		public string CreateBy { get; set; }
		public DateTime CreateDate { get; set; }
		public string FileDokumen { get; set; }
		public string FileDokumenId { get; set; }
		public Guid? IdVendor { get; set; }
		public string Kondisi { get; set; }
		public string NoDokumen { get; set; }
		public string PeriodeAkhir { get; set; }
		public string PeriodeAwal { get; set; }
		public int? Tahun { get; set; }
		public DateTime? Tanggal { get; set; }
		public DateTime? TanggalAkhir { get; set; }
		public string TipeDokumen { get; set; }
		public string UpdateBy { get; set; }
		public DateTime? UpdateDate { get; set; }

    }
}

