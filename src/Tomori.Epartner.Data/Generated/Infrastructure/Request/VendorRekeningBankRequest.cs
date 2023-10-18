using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class VendorRekeningBankRequest
    {
		[Required]
		public int CivdId { get; set; }
		public DateTime? CompletedDate { get; set; }
		public string FileSuratPernyataan { get; set; }
		public string FileSuratPernyataanId { get; set; }
		public Guid? IdVendor { get; set; }
		public string JenisMataUang { get; set; }
		public string KantorCabang { get; set; }
		public string NamaBank { get; set; }
		public string Negara { get; set; }
		public string NoRekening { get; set; }
		public string NoRekeningFormat { get; set; }
		public string PemegangRekening { get; set; }

    }
}

