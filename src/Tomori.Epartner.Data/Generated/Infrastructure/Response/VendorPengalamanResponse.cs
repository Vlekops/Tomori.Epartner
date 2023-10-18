using System;
using System.Linq;
using System.Text;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class VendorPengalamanResponse
    {
		public Guid Id { get; set; }
		public string Alamat { get; set; }
		public string BidangSubBidang { get; set; }
		public string BidangSubBidangCode { get; set; }
		public int CivdId { get; set; }
		public DateTime? CompletedDate { get; set; }
		public string CreateBy { get; set; }
		public DateTime CreateDate { get; set; }
		public string FileBast { get; set; }
		public string FileBastId { get; set; }
		public string FileBuktiPengalaman { get; set; }
		public string FileBuktiPengalamanId { get; set; }
		public Guid? IdVendor { get; set; }
		public string JenisMataUang { get; set; }
		public string Lokasi { get; set; }
		public string NamaPaketPekerjaan { get; set; }
		public string NamaPenggunaJasa { get; set; }
		public long? NilaiKontrakPo { get; set; }
		public string NoKontrakPo { get; set; }
		public string NoTelepon { get; set; }
		public DateTime? SelesaiKontrakPo { get; set; }
		public DateTime? TglKontrakPo { get; set; }
		public string UpdateBy { get; set; }
		public DateTime? UpdateDate { get; set; }

    }
}

