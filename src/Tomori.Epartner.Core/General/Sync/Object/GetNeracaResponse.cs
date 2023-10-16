using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Core.Attributes;
using DocumentFormat.OpenXml.Office.CoverPageProps;

namespace Tomori.Epartner.Core.Response
{
    public partial class GetNeracaResponse
    {
        public int id { get; set; }
        public int vendorId { get; set; }
        public string compTypeDesc { get; set; }
        public string vendorName { get; set; }
        public string k3sName { get; set; }
        public int tahun { get; set; }
        public string jenisMataUang { get; set; }
        public long jumlahAktiva { get; set; }
        public long jumlahUtang { get; set; }
        public long kekayaanBersih { get; set; }
        public int zeroControl { get; set; }
        public int tanahBangunan { get; set; }
        public long netEkuitas { get; set; }
        public string jenisMataUangSales { get; set; }
        public long penjualan { get; set; }
        public string golonganPerusahaan { get; set; }
        public string statusAudit { get; set; }
        public string statusAuditAktual { get; set; }
        public string fileNeraca { get; set; }
        public string perusahaanBaru { get; set; }
        public string fileNeracaId { get; set; }
        public string periodeAwal { get; set; }
        public string periodeAkhir { get; set; }
        public long cash { get; set; }
        public long accountReceivables { get; set; }
        public long otherCurrentAsset { get; set; }
        public long currentAsset { get; set; }
        public long fixedAsset { get; set; }
        public long currentLiabilities { get; set; }
        public long nonCurrentLiabilities { get; set; }
        public long costOfRevenue { get; set; }
        public long grossProfit { get; set; }
        public long operatingExpense { get; set; }
        public long ebit { get; set; }
        public long interestExpense { get; set; }
        public long othersExpense { get; set; }
        public long othersIncome { get; set; }
        public long earningBeforeTax { get; set; }
        public long netProfit { get; set; }
        public long depreciationExpense { get; set; }
        public DateTime? tanggalSales { get; set; }
        public DateTime? tanggalAkhirSales { get; set; }
        public DateTime? akhirBerlaku { get; set; }
        public DateTime? completedDate { get; set; }
    }
}

