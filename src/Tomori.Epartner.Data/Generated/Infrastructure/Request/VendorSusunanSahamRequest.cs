using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class VendorSusunanSahamRequest
    {
		public string BadanUsaha { get; set; }
		[Required]
		public int CivdId { get; set; }
		public DateTime? CompletedDate { get; set; }
		public string DocNpwp { get; set; }
		public string Email { get; set; }
		public Guid? IdVendor { get; set; }
		[Required]
		public decimal JumlahSaham { get; set; }
		public string Nama { get; set; }
		public string NoKtpKitas { get; set; }
		[Required]
		public bool Perorangan { get; set; }
		public string WargaNegara { get; set; }

    }
}

