using System;
using System.Linq;
using System.Text;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class VendorLandasanHukumResponse
    {
		public Guid Id { get; set; }
		public int CivdId { get; set; }
		public DateTime? CompletedDate { get; set; }
		public string CreateBy { get; set; }
		public DateTime CreateDate { get; set; }
		public string FileLandasanHukum { get; set; }
		public string FileLandasanHukumId { get; set; }
		public Guid? IdVendor { get; set; }
		public string JenisAkta { get; set; }
		public string NamaNotaris { get; set; }
		public string NamaSkMenteri { get; set; }
		public string NoAkta { get; set; }
		public DateTime? TglAkta { get; set; }
		public string UpdateBy { get; set; }
		public DateTime? UpdateDate { get; set; }

    }
}

