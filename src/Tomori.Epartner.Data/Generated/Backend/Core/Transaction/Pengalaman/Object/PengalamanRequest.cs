//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Core.Request
{
    public partial class PengalamanRequest
    {
		public string Alamat{ get; set; }
		public string BidangSubBidang{ get; set; }
		public string BidangSubBidangCode{ get; set; }
		public string FileBast{ get; set; }
		public Guid? FileBastId{ get; set; }
		public string FileBuktiPengalaman{ get; set; }
		public Guid? FileBuktiPengalamanId{ get; set; }
		public string JenisMataUang{ get; set; }
		public string Lokasi{ get; set; }
		public string NamaPaketPekerjaan{ get; set; }
		public string NamaPenggunaJasa{ get; set; }
		public long? NilaiKontrakPo{ get; set; }
		public string NoKontrakPo{ get; set; }
		public string NoTelepon{ get; set; }
		public DateTime? SelesaiKontrakPo{ get; set; }
		public DateTime? TglKontrakPo{ get; set; }
		[Required]
		public int VendorId{ get; set; }

    }
}
