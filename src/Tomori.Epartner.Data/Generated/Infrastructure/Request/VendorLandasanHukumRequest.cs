using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class VendorLandasanHukumRequest
    {
		[Required]
		public int CivdId { get; set; }
		public DateTime? CompletedDate { get; set; }
		public string FileLandasanHukum { get; set; }
		public string FileLandasanHukumId { get; set; }
		public Guid? IdVendor { get; set; }
		public string JenisAkta { get; set; }
		public string NamaNotaris { get; set; }
		public string NamaSkMenteri { get; set; }
		public string NoAkta { get; set; }
		public DateTime? TglAkta { get; set; }

    }
}

