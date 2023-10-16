using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Core.Attributes;
using DocumentFormat.OpenXml.Office.CoverPageProps;

namespace Tomori.Epartner.Core.Response
{
    public partial class GetSpdaHistoryResponse
    {
        public int id { get; set; }
        public int vendorId { get; set; }
        public string vendorName { get; set; }
        public string k3sName { get; set; }
        public string spdaNo { get; set; }
        public string fileSPDA { get; set; }
        public string spdaValidity { get; set; }
        public string fileSPDAId { get; set; }
        public DateTime? uploadDate { get; set; }
        public DateTime? expiredDate { get; set; }
    }
}

