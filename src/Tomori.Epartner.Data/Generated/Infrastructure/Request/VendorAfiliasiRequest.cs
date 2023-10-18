using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class VendorAfiliasiRequest
    {
		[Required]
		public int CivdId { get; set; }
		public DateTime? CompletedDate { get; set; }
		public string Deskripsi { get; set; }
		public string FileAfiliasiId { get; set; }
		public Guid? IdVendor { get; set; }
		public decimal? Share { get; set; }
		public string Terafiliasi { get; set; }
		public string TipeAfiliasi { get; set; }

    }
}

