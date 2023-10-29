namespace Tomori.Epartner.Web.Component.Services
{
    public partial class VendorRekeningBankResponse
    {
        public Guid Id { get; set; }
        public int CivdId { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string FileSuratPernyataan { get; set; }
        public string FileSuratPernyataanId { get; set; }
        public Guid? IdVendor { get; set; }
        public string JenisMataUang { get; set; }
        public string KantorCabang { get; set; }
        public string NamaBank { get; set; }
        public string Negara { get; set; }
        public string NoRekening { get; set; }
        public string NoRekeningFormat { get; set; }
        public string PemegangRekening { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
    public partial class VendorRekeningBankRequest
    {
        [Required]
        public int CivdId { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string FileSuratPernyataan { get; set; }
        public string FileSuratPernyataanId { get; set; }
        public Guid? IdVendor { get; set; }
        public string JenisMataUang { get; set; }
        public string KantorCabang { get; set; }
        public string NamaBank { get; set; }
        public string Negara { get; set; }
        public string NoRekening { get; set; }
        public string NoRekeningFormat { get; set; }
        public string PemegangRekening { get; set; }

    }
    public interface IVendorRekeningBankService
    {
        Task<ObjectResponse<VendorRekeningBankResponse>> Get(Guid id, string baseUrl, string token);
        Task<ListResponse<VendorRekeningBankResponse>> List(ListRequest request, string baseUrl, string token);
        Task<StatusResponse> Add(VendorRekeningBankRequest request, string baseUrl, string token);
        Task<StatusResponse> Edit(Guid id, VendorRekeningBankRequest request, string baseUrl, string token);
        Task<StatusResponse> Delete(Guid id, string baseUrl, string token);

    }
    public class VendorRekeningBankService : IVendorRekeningBankService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public VendorRekeningBankService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<VendorRekeningBankResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<VendorRekeningBankResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/VendorRekeningBank/get/{id}", null));
        }
        
        public async Task<ListResponse<VendorRekeningBankResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<VendorRekeningBankResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorRekeningBank/list", request));
        }
        
        public async Task<StatusResponse> Add(VendorRekeningBankRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorRekeningBank/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, VendorRekeningBankRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/VendorRekeningBank/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/VendorRekeningBank/delete/{id}", null));
        }
        
    }
}

