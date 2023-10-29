using System;
using System.Linq;
using System.Text;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class VendorSpdaResponse
    {
		public Guid Id { get; set; }
		public int CivdId { get; set; }
		public string CreateBy { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime? ExpiredDate { get; set; }
		public string FileSpda { get; set; }
		public string FileSpdaId { get; set; }
		public Guid? IdVendor { get; set; }
		public string SpdaNo { get; set; }
		public string SpdaValidity { get; set; }
		public string UpdateBy { get; set; }
		public DateTime? UpdateDate { get; set; }
		public DateTime? UploadDate { get; set; }

    }
}

