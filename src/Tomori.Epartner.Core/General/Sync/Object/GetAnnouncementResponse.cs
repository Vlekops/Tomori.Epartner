using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Core.Attributes;
using DocumentFormat.OpenXml.Office.CoverPageProps;

namespace Tomori.Epartner.Core.Response
{
    public partial class GetAnnouncementResponse
    {
        public int id { get; set; }
        public int k3sId { get; set; }
        public string k3sName { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string attachment { get; set; }
        public string announcementCategory { get; set; }
        public string announcementType { get; set; }
        public string tenderType { get; set; }
        public string bidangUsaha { get; set; }
        public string golonganUsaha { get; set; }
        public int previousId { get; set; }
        public DateTime publishDate { get; set; }
        public DateTime endDate { get; set; }
        public DateTime createdDate { get; set; }
    }
}

