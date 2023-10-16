using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Core.Attributes;
using DocumentFormat.OpenXml.Office.CoverPageProps;

namespace Tomori.Epartner.Core.Response
{
    public partial class GetLandasanHukumResponse
    {
        public int id { get; set; }
        public int vendorId { get; set; }
        public string compTypeDesc { get; set; }
        public string vendorName { get; set; }
        public string k3sName { get; set; }
        public string jenisAkta { get; set; }
        public string noAkta { get; set; }
        public string namaNotaris { get; set; }
        public string noSKMenteri { get; set; }
        public string fileLandasanHukum { get; set; }
        public string countryIssuedForeign { get; set; }
        public string fileLandasanHukumId { get; set; }
        public DateTime? tanggalAkta { get; set; }
        public DateTime? completedDate { get; set; }
    }
}

