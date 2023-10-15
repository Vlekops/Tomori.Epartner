using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Core.Attributes;
using DocumentFormat.OpenXml.Office.CoverPageProps;

namespace Tomori.Epartner.Core.Response
{
    public partial class GetIzinUsahaResponse
    {
        public int id { get; set; }
        public int vendorId { get; set; }
        public string compTypeDesc { get; set; }
        public string vendorName { get; set; }
        public string k3sName { get; set; }
        public string jenisIzinUsaha { get; set; }
        public string others { get; set; }
        public string bidangUsaha { get; set; }
        public string golonganUsaha { get; set; }
        public string noIzinUsaha { get; set; }
        public string instansiPemberiIzin { get; set; }
        public string fileIzinUsaha { get; set; }
        public string tipeSTP { get; set; }
        public string merkSTP { get; set; }
        public string peringkatInspeksi { get; set; }
        public Guid fileIzinUsahaId { get; set; }
        public string bidangUsahaCode { get; set; }
        public string jenisMataUang { get; set; }
        public decimal kekayaanBersih { get; set; }
        public DateTime mulaiBerlaku { get; set; }
        public DateTime akhirBerlaku { get; set; }
        public DateTime completedDate { get; set; }
    }
}

