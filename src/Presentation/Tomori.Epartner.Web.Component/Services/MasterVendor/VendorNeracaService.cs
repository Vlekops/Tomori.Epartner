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
    public interface IVendorNeracaService
    {
        Task<ObjectResponse<VendorNeracaResponse>> Get(Guid id, string baseUrl, string token);
        Task<ListResponse<VendorNeracaResponse>> List(ListRequest request, string baseUrl, string token);
        Task<StatusResponse> Add(VendorNeracaRequest request, string baseUrl, string token);
        Task<StatusResponse> Edit(Guid id, VendorNeracaRequest request, string baseUrl, string token);
        Task<StatusResponse> Delete(Guid id, string baseUrl, string token);

    }
    public class VendorNeracaService : IVendorNeracaService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public VendorNeracaService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<VendorNeracaResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<VendorNeracaResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/VendorNeraca/get/{id}", null));
        }
        
        public async Task<ListResponse<VendorNeracaResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<VendorNeracaResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorNeraca/list", request));
        }
        
        public async Task<StatusResponse> Add(VendorNeracaRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorNeraca/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, VendorNeracaRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/VendorNeraca/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/VendorNeraca/delete/{id}", null));
        }
        
    }
}

