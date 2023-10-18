using System;
using System.Linq;
using System.Text;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class VendorAfiliasiResponse
    {
		public Guid Id { get; set; }
		public int CivdId { get; set; }
		public DateTime? CompletedDate { get; set; }
		public string CreateBy { get; set; }
		public DateTime CreateDate { get; set; }
		public string Deskripsi { get; set; }
		public string FileAfiliasiId { get; set; }
		public Guid? IdVendor { get; set; }
		public decimal? Share { get; set; }
		public string Terafiliasi { get; set; }
		public string TipeAfiliasi { get; set; }
		public string UpdateBy { get; set; }
		public DateTime? UpdateDate { get; set; }

    }
}

