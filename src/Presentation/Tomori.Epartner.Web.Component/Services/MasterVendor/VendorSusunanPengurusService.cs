namespace Tomori.Epartner.Web.Component.Services
{
    public partial class VendorSusunanPengurusResponse
    {
        public Guid Id { get; set; }
        public int CivdId { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string Email { get; set; }
        public string FileKtpKitas { get; set; }
        public string FileKtpKitasId { get; set; }
        public string FileTandaTangan { get; set; }
        public string FileTandaTanganId { get; set; }
        public Guid? IdVendor { get; set; }
        public string Jabatan { get; set; }
        public string Nama { get; set; }
        public string NoKtpKitas { get; set; }
        public string TipePengurus { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
    public partial class VendorSusunanPengurusRequest
    {
        [Required]
        public int CivdId { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string Email { get; set; }
        public string FileKtpKitas { get; set; }
        public string FileKtpKitasId { get; set; }
        public string FileTandaTangan { get; set; }
        public string FileTandaTanganId { get; set; }
        public Guid? IdVendor { get; set; }
        public string Jabatan { get; set; }
        public string Nama { get; set; }
        public string NoKtpKitas { get; set; }
        public string TipePengurus { get; set; }

    }
    public interface IVendorSusunanPengurusService
    {
        Task<ObjectResponse<VendorSusunanPengurusResponse>> Get(Guid id, string baseUrl, string token);
        Task<ListResponse<VendorSusunanPengurusResponse>> List(ListRequest request, string baseUrl, string token);
        Task<StatusResponse> Add(VendorSusunanPengurusRequest request, string baseUrl, string token);
        Task<StatusResponse> Edit(Guid id, VendorSusunanPengurusRequest request, string baseUrl, string token);
        Task<StatusResponse> Delete(Guid id, string baseUrl, string token);

    }
    public class VendorSusunanPengurusService : IVendorSusunanPengurusService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public VendorSusunanPengurusService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<VendorSusunanPengurusResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<VendorSusunanPengurusResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/VendorSusunanPengurus/get/{id}", null));
        }
        
        public async Task<ListResponse<VendorSusunanPengurusResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<VendorSusunanPengurusResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorSusunanPengurus/list", request));
        }
        
        public async Task<StatusResponse> Add(VendorSusunanPengurusRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorSusunanPengurus/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, VendorSusunanPengurusRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/VendorSusunanPengurus/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/VendorSusunanPengurus/delete/{id}", null));
        }
        
    }
}

