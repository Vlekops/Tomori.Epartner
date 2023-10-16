using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Core.Attributes;
using DocumentFormat.OpenXml.Office.CoverPageProps;

namespace Tomori.Epartner.Core.Response
{
    public partial class GetRekeningBankResponse
    {
        public int id { get; set; }
        public int vendorId { get; set; }
        public string compTypeDesc { get; set; }
        public string vendorName { get; set; }
        public string k3sName { get; set; }
        public string pemegangRekening { get; set; }
        public string noRekening { get; set; }
        public string noRekeningNoFormat { get; set; }
        public string jenisMataUang { get; set; }
        public string namaBank { get; set; }
        public string kantorCabang { get; set; }
        public string negara { get; set; }
        public string fileSuratPernyataan { get; set; }
        public string fileSuratPernyataanId { get; set; }
        public DateTime completedDate { get; set; }
    }
}

