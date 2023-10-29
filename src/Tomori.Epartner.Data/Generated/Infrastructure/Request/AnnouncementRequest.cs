using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class AnnouncementRequest
    {
		public string AnnouncementCategory { get; set; }
		public string AnnouncementType { get; set; }
		public string Attachment { get; set; }
		public string BidangUsaha { get; set; }
		[Required]
		public int CivdId { get; set; }
		public string Description { get; set; }
		public DateTime? EndDate { get; set; }
		public string GolonganUsaha { get; set; }
		[Required]
		public int K3sId { get; set; }
		public string K3sName { get; set; }
		public int? PreviousId { get; set; }
		public DateTime? PublishDate { get; set; }
		public string TenderType { get; set; }
		public string Title { get; set; }

    }
}

