using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class VendorNeracaRequest
    {
		[Required]
		public long AccountReceivables { get; set; }
		public DateTime? AkhirBerlaku { get; set; }
		[Required]
		public long Cash { get; set; }
		[Required]
		public int CivdId { get; set; }
		public DateTime? CompletedDate { get; set; }
		[Required]
		public long CostOfRevenue { get; set; }
		[Required]
		public long CurrentAsset { get; set; }
		[Required]
		public long CurrentLiabilities { get; set; }
		[Required]
		public long DepreciationExpense { get; set; }
		[Required]
		public long EarningBeforeTax { get; set; }
		[Required]
		public long Ebit { get; set; }
		public string FileNeraca { get; set; }
		public string FileNeracaId { get; set; }
		[Required]
		public long FixedAsset { get; set; }
		public string GolonganPerusahaan { get; set; }
		[Required]
		public long GrossProfit { get; set; }
		public Guid? IdVendor { get; set; }
		[Required]
		public long InterestExpense { get; set; }
		public string JenisMataUang { get; set; }
		public string JenisMataUangSales { get; set; }
		[Required]
		public long JumlahAktiva { get; set; }
		[Required]
		public long JumlahHutang { get; set; }
		[Required]
		public long KekayaanBersih { get; set; }
		[Required]
		public long NetEkuitas { get; set; }
		[Required]
		public long NetProfit { get; set; }
		[Required]
		public long NonCurrentLiabilities { get; set; }
		[Required]
		public long OperatingExpense { get; set; }
		[Required]
		public long OtherCurrentAsset { get; set; }
		[Required]
		public long OthersExpense { get; set; }
		[Required]
		public long OthersIncome { get; set; }
		[Required]
		public long Penjualan { get; set; }
		public string PeriodeAkhir { get; set; }
		public string PeriodeAwal { get; set; }
		public string StatusAudit { get; set; }
		[Required]
		public int Tahun { get; set; }
		[Required]
		public int TanahBangunan { get; set; }
		public DateTime? TglAkhirSales { get; set; }
		public DateTime? TglSales { get; set; }
		[Required]
		public int ZeroControl { get; set; }

    }
}

