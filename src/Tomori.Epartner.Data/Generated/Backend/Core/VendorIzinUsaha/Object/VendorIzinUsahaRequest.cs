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
    public partial class VendorIzinUsahaRequest
    {
		public DateTime? AkhirBerlaku{ get; set; }
		public string BidangUsaha{ get; set; }
		public string BidangUsahaCode{ get; set; }
		[Required]
		public int CivdId{ get; set; }
		public DateTime? CompletedDate{ get; set; }
		public string FileIzinUsaha{ get; set; }
		public string FileIzinUsahaId{ get; set; }
		public string GolonganUsaha{ get; set; }
		public Guid? IdVendor{ get; set; }
		public string InstansiPemberiIzin{ get; set; }
		public string JenisIzinUsaha{ get; set; }
		public string JenisMataUang{ get; set; }
		public decimal? KekayaanBershi{ get; set; }
		public string MerkStp{ get; set; }
		public DateTime? MulaiBerlaku{ get; set; }
		public string NoIzinUsaha{ get; set; }
		public string Other{ get; set; }
		public string PeringkatInspeksi{ get; set; }
		public string TipeStp{ get; set; }

    }
}

