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
    public partial class VendorSpdaRequest
    {
		[Required]
		public int CivdId{ get; set; }
		public DateTime? ExpiredDate{ get; set; }
		public string FileSpda{ get; set; }
		public string FileSpdaId{ get; set; }
		public Guid? IdVendor{ get; set; }
		public string SpdaNo{ get; set; }
		public string SpdaValidity{ get; set; }
		public DateTime? UploadDate{ get; set; }

    }
}

