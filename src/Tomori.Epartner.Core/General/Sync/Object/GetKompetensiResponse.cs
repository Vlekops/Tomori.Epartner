namespace Tomori.Epartner.Core.Response
{
    public partial class GetKompetensiResponse
    {
        public int id { get; set; }
        public int vendorId { get; set; }
        public string compTypeDesc { get; set; }
        public string vendorName { get; set; }
        public string k3sName { get; set; }
        public string bidangSubBidangCode { get; set; }
        public string bidangSubBidang { get; set; }
        public string deskripsi { get; set; }
        public string perusahaan { get; set; }
        public string noKontrakPOSO { get; set; }
        public string jenisMataUang { get; set; }
        public string nilaiKontrakPOSO { get; set; }
        public string progressKontrakPOSO { get; set; }
        public string dokumen { get; set; }
        public string dokumenId { get; set; }
        public DateTime? completedDate { get; set; }
        public DateTime? tanggalKontrakPOSO { get; set; }
        public DateTime? tanggalPenyelesaian { get; set; }
    }
}

