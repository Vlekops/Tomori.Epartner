using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Core.Attributes;
using DocumentFormat.OpenXml.Office.CoverPageProps;

namespace Tomori.Epartner.Core.Response
{
    public partial class GetSanksiHistoryResponse
    {
        public int id { get; set; }
        public int? vendorId { get; set; }
        public string vendorName { get; set; }
        public string k3sName { get; set; }
        public string sanksi { get; set; }
        public string keterangan { get; set; }
        public string percobaan { get; set; }
        public string fileSuratSanksi { get; set; }
        public string filePernyataanPerbaikan { get; set; }
        public string fileSanksiId { get; set; }
        public DateTime? tanggalBerlakuSanksi { get; set; }
        public DateTime? tanggalBerakhirSanksi { get; set; }
        public DateTime? tanggalBerakhirPercobaan { get; set; }
        public DateTime? tanggalPelepasanSanksi { get; set; }
    }
}

