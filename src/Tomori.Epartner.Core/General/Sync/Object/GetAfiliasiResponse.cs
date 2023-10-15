using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Core.Attributes;
using DocumentFormat.OpenXml.Office.CoverPageProps;

namespace Tomori.Epartner.Core.Response
{
    public partial class GetAfiliasiResponse
    {
        public int id { get; set; }
        public int vendorId { get; set; }
        public string compTypeDesc { get; set; }
        public string vendorName { get; set; }
        public string k3sName { get; set; }
        public string tipeAfiliasi { get; set; }
        public string deskripsi { get; set; }
        public int share { get; set; }
        public string tipePerusahaan { get; set; }
        public string namaPerusahaan { get; set; }
        public string statusPerusahaan { get; set; }
        public string alamatPerusahaan { get; set; }
        public string negara { get; set; }
        public string propinsi { get; set; }
        public string kota { get; set; }
        public string kodePos { get; set; }
        public string nomorTelepon { get; set; }
        public string nomorFax { get; set; }
        public string namaKontak { get; set; }
        public string emailKontak { get; set; }
        public string fileAfiliasi { get; set; }
        public string terafiliasi { get; set; }
        public string vendorNPWP { get; set; }
        public string countryForeign { get; set; }
        public string docNPWP { get; set; }
        public Guid fileAfiliasiId { get; set; }
        public DateTime completedDate { get; set; }

    }
}

