using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Core.Attributes;
using DocumentFormat.OpenXml.Office.CoverPageProps;

namespace Tomori.Epartner.Core.Response
{
    public partial class GetSusunanSahamResponse
    {
        public int id { get; set; }
        public int vendorId { get; set; }
        public string compTypeDesc { get; set; }
        public string vendorName { get; set; }
        public string k3sName { get; set; }
        public string nama { get; set; }
        public bool perorangan { get; set; }
        public string wargaNegara { get; set; }
        public string badanUsaha { get; set; }
        public decimal jumlahSaham { get; set; }
        public string email { get; set; }
        public string noKTPKITAS { get; set; }
        public string vendorNPWP { get; set; }
        public string fileIDid { get; set; }
        public string fileId { get; set; }
        public string docNPWP { get; set; }
        public DateTime completedDate { get; set; }
    }
}

