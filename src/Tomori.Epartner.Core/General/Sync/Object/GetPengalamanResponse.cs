using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Core.Attributes;
using DocumentFormat.OpenXml.Office.CoverPageProps;

namespace Tomori.Epartner.Core.Response
{
    public partial class GetPengalamanResponse
    {
        public int id { get; set; }
        public int vendorId { get; set; }
        public string compTypeDesc { get; set; }
        public string vendorName { get; set; }
        public string k3sName { get; set; }
        public string namaPaketPekerjaan { get; set; }
        public string bidangSubbidangCode { get; set; }
        public string bidangSubbidang { get; set; }
        public string lokasi { get; set; }
        public string namaPenggunaJasa { get; set; }
        public string alamat { get; set; }
        public string noTelepon { get; set; }
        public string noKontrakPo { get; set; }
        public string jenisMataUang { get; set; }
        public long? nilaiKontrakPo { get; set; }
        public string fileBast { get; set; }
        public string fileBuktiPengalaman { get; set; }
        public string fileBastId { get; set; }
        public string fileBuktiPengalamanId { get; set; }
        public string companyType { get; set; }
        public DateTime selesaiKontrakPo { get; set; }
        public DateTime tanggalKontrakPo { get; set; }
        public DateTime completedDate { get; set; }
}
}

