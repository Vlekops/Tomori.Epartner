//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Core.Request
{
    public partial class VendorSusunanSahamRequest
    {
		public string BadanUsaha{ get; set; }
		[Required]
		public int CivdId{ get; set; }
		public DateTime? CompletedDate{ get; set; }
		public string DocNpwp{ get; set; }
		public string Email{ get; set; }
		public Guid? IdVendor{ get; set; }
		[Required]
		public decimal JumlahSaham{ get; set; }
		public string Nama{ get; set; }
		public string NoKtpKitas{ get; set; }
		[Required]
		public bool Perorangan{ get; set; }
		public string WargaNegara{ get; set; }

    }
}

