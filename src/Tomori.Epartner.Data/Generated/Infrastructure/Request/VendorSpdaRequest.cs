using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class VendorSpdaRequest
    {
		[Required]
		public int CivdId { get; set; }
		public DateTime? ExpiredDate { get; set; }
		public string FileSpda { get; set; }
		public string FileSpdaId { get; set; }
		public Guid? IdVendor { get; set; }
		public string SpdaNo { get; set; }
		public string SpdaValidity { get; set; }
		public DateTime? UploadDate { get; set; }

    }
}

