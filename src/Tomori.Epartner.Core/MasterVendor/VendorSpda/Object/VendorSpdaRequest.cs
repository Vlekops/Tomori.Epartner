//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
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

