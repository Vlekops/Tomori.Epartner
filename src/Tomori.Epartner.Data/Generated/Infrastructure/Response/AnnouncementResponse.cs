using System;
using System.Linq;
using System.Text;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class AnnouncementResponse
    {
		public Guid Id { get; set; }
		public string AnnouncementCategory { get; set; }
		public string AnnouncementType { get; set; }
		public string Attachment { get; set; }
		public string BidangUsaha { get; set; }
		public int CivdId { get; set; }
		public string CreateBy { get; set; }
		public DateTime CreateDate { get; set; }
		public string Description { get; set; }
		public DateTime? EndDate { get; set; }
		public string GolonganUsaha { get; set; }
		public int K3sId { get; set; }
		public string K3sName { get; set; }
		public int? PreviousId { get; set; }
		public DateTime? PublishDate { get; set; }
		public string TenderType { get; set; }
		public string Title { get; set; }
		public string UpdateBy { get; set; }
		public DateTime? UpdateDate { get; set; }

    }
}

