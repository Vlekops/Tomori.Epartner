using System;
using System.Linq;
using System.Text;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class VendorNeracaResponse
    {
		public Guid Id { get; set; }
		public long AccountReceivables { get; set; }
		public DateTime? AkhirBerlaku { get; set; }
		public long Cash { get; set; }
		public int CivdId { get; set; }
		public DateTime? CompletedDate { get; set; }
		public long CostOfRevenue { get; set; }
		public string CreateBy { get; set; }
		public DateTime CreateDate { get; set; }
		public long CurrentAsset { get; set; }
		public long CurrentLiabilities { get; set; }
		public long DepreciationExpense { get; set; }
		public long EarningBeforeTax { get; set; }
		public long Ebit { get; set; }
		public string FileNeraca { get; set; }
		public string FileNeracaId { get; set; }
		public long FixedAsset { get; set; }
		public string GolonganPerusahaan { get; set; }
		public long GrossProfit { get; set; }
		public Guid? IdVendor { get; set; }
		public long InterestExpense { get; set; }
		public string JenisMataUang { get; set; }
		public string JenisMataUangSales { get; set; }
		public long JumlahAktiva { get; set; }
		public long JumlahHutang { get; set; }
		public long KekayaanBersih { get; set; }
		public long NetEkuitas { get; set; }
		public long NetProfit { get; set; }
		public long NonCurrentLiabilities { get; set; }
		public long OperatingExpense { get; set; }
		public long OtherCurrentAsset { get; set; }
		public long OthersExpense { get; set; }
		public long OthersIncome { get; set; }
		public long Penjualan { get; set; }
		public string PeriodeAkhir { get; set; }
		public string PeriodeAwal { get; set; }
		public string StatusAudit { get; set; }
		public int Tahun { get; set; }
		public int TanahBangunan { get; set; }
		public DateTime? TglAkhirSales { get; set; }
		public DateTime? TglSales { get; set; }
		public string UpdateBy { get; set; }
		public DateTime? UpdateDate { get; set; }
		public int ZeroControl { get; set; }

    }
}

