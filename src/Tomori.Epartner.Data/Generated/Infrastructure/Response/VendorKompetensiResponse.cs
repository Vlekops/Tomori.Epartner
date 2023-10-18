using System;
using System.Linq;
using System.Text;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class VendorKompetensiResponse
    {
		public Guid Id { get; set; }
		public string BidangSubBidang { get; set; }
		public string BidangSubBidangCode { get; set; }
		public int CivdId { get; set; }
		public DateTime? CompletedDate { get; set; }
		public string CreateBy { get; set; }
		public DateTime CreateDate { get; set; }
		public string Deskripsi { get; set; }
		public string Document { get; set; }
		public string DocumentId { get; set; }
		public Guid? IdVendor { get; set; }
		public string JenisMataUang { get; set; }
		public long? NilaiKontrakPoso { get; set; }
		public string NoKontrakPoso { get; set; }
		public string Perusahaan { get; set; }
		public string ProgressKontrakPoso { get; set; }
		public DateTime? TglKontrakPoso { get; set; }
		public DateTime? TglPenyelesaian { get; set; }
		public string UpdateBy { get; set; }
		public DateTime? UpdateDate { get; set; }

    }
}

