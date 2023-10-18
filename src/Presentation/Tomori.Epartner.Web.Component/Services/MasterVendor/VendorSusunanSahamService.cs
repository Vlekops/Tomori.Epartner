namespace Tomori.Epartner.Web.Component.Services
{
    public partial class VendorSusunanSahamResponse
    {
        public Guid Id { get; set; }
        public string BadanUsaha { get; set; }
        public int CivdId { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string DocNpwp { get; set; }
        public string Email { get; set; }
        public Guid? IdVendor { get; set; }
        public decimal JumlahSaham { get; set; }
        public string Nama { get; set; }
        public string NoKtpKitas { get; set; }
        public bool Perorangan { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string WargaNegara { get; set; }

    }
    public partial class VendorSusunanSahamRequest
    {
        public string BadanUsaha { get; set; }
        [Required]
        public int CivdId { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string DocNpwp { get; set; }
        public string Email { get; set; }
        public Guid? IdVendor { get; set; }
        [Required]
        public decimal JumlahSaham { get; set; }
        public string Nama { get; set; }
        public string NoKtpKitas { get; set; }
        [Required]
        public bool Perorangan { get; set; }
        public string WargaNegara { get; set; }

    }
    public interface IVendorSusunanSahamService
    {
        Task<ObjectResponse<VendorSusunanSahamResponse>> Get(Guid id, string baseUrl, string token);
        Task<ListResponse<VendorSusunanSahamResponse>> List(ListRequest request, string baseUrl, string token);
        Task<StatusResponse> Add(VendorSusunanSahamRequest request, string baseUrl, string token);
        Task<StatusResponse> Edit(Guid id, VendorSusunanSahamRequest request, string baseUrl, string token);
        Task<StatusResponse> Delete(Guid id, string baseUrl, string token);

    }
    public class VendorSusunanSahamService : IVendorSusunanSahamService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public VendorSusunanSahamService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<VendorSusunanSahamResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<VendorSusunanSahamResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/VendorSusunanSaham/get/{id}", null));
        }
        
        public async Task<ListResponse<VendorSusunanSahamResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<VendorSusunanSahamResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorSusunanSaham/list", request));
        }
        
        public async Task<StatusResponse> Add(VendorSusunanSahamRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorSusunanSaham/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, VendorSusunanSahamRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/VendorSusunanSaham/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/VendorSusunanSaham/delete/{id}", null));
        }
        
    }
}

