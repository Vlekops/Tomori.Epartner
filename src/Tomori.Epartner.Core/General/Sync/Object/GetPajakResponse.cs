using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Core.Attributes;
using DocumentFormat.OpenXml.Office.CoverPageProps;

namespace Tomori.Epartner.Core.Response
{
    public partial class GetPajakResponse
    {
        public int id { get; set; }
        public int vendorId { get; set; }
        public string compTypeDesc { get; set; }
        public string vendorName { get; set; }
        public string k3sName { get; set; }
        public string tipeDokumen { get; set; }
        public string noDokumen { get; set; }
        public string fileDokumen { get; set; }
        public string kondisi { get; set; }
        public string periodeAwal { get; set; }
        public string periodeAkhir { get; set; }
        public int tahun { get; set; }
        public Guid fileDokumenId { get; set; }
        public DateTime completedDate{ get; set; }
        public DateTime? tanggal { get; set; }
        public DateTime tanggalAkhir { get; set; }
    }
}

