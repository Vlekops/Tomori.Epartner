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
    public partial class VendorSusunanPengurusRequest
    {
		[Required]
		public int CivdId{ get; set; }
		public DateTime? CompletedDate{ get; set; }
		public string Email{ get; set; }
		public string FileKtpKitas{ get; set; }
		public string FileKtpKitasId{ get; set; }
		public string FileTandaTangan{ get; set; }
		public string FileTandaTanganId{ get; set; }
		public Guid? IdVendor{ get; set; }
		public string Jabatan{ get; set; }
		public string Nama{ get; set; }
		public string NoKtpKitas{ get; set; }
		public string TipePengurus{ get; set; }

    }
}
