using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class VendorSusunanPengurusRequest
    {
		[Required]
		public int CivdId { get; set; }
		public DateTime? CompletedDate { get; set; }
		public string Email { get; set; }
		public string FileKtpKitas { get; set; }
		public string FileKtpKitasId { get; set; }
		public string FileTandaTangan { get; set; }
		public string FileTandaTanganId { get; set; }
		public Guid? IdVendor { get; set; }
		public string Jabatan { get; set; }
		public string Nama { get; set; }
		public string NoKtpKitas { get; set; }
		public string TipePengurus { get; set; }

    }
}

