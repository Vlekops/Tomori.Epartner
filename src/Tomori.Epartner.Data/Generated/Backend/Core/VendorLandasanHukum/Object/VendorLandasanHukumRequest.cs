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
    public partial class VendorLandasanHukumRequest
    {
		[Required]
		public int CivdId{ get; set; }
		public DateTime? CompletedDate{ get; set; }
		public string FileLandasanHukum{ get; set; }
		public string FileLandasanHukumId{ get; set; }
		public Guid? IdVendor{ get; set; }
		public string JenisAkta{ get; set; }
		public string NamaNotaris{ get; set; }
		public string NamaSkMenteri{ get; set; }
		public string NoAkta{ get; set; }
		public DateTime? TglAkta{ get; set; }

    }
}
