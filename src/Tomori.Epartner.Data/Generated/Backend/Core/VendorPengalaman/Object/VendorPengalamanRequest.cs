//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
<<<<<<< HEAD
//     Manual changes to this file will be overwritten if the code is regenerated.
=======
>>>>>>> 5d5d61fd98f85493183e29a5767ce20080f32c00
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Core.Request
{
    public partial class VendorPengalamanRequest
    {
		public string Alamat{ get; set; }
		public string BidangSubBidang{ get; set; }
		public string BidangSubBidangCode{ get; set; }
		[Required]
		public int CivdId{ get; set; }
		public DateTime? CompletedDate{ get; set; }
		public string FileBast{ get; set; }
		public string FileBastId{ get; set; }
		public string FileBuktiPengalaman{ get; set; }
		public string FileBuktiPengalamanId{ get; set; }
		public Guid? IdVendor{ get; set; }
		public string JenisMataUang{ get; set; }
		public string Lokasi{ get; set; }
		public string NamaPaketPekerjaan{ get; set; }
		public string NamaPenggunaJasa{ get; set; }
		public long? NilaiKontrakPo{ get; set; }
		public string NoKontrakPo{ get; set; }
		public string NoTelepon{ get; set; }
		public DateTime? SelesaiKontrakPo{ get; set; }
		public DateTime? TglKontrakPo{ get; set; }

    }
}

