namespace Tomori.Epartner.Web.Component.Services
{
    public partial class VendorLandasanHukumResponse
    {
        public Guid Id { get; set; }
        public int CivdId { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string FileLandasanHukum { get; set; }
        public string FileLandasanHukumId { get; set; }
        public Guid? IdVendor { get; set; }
        public string JenisAkta { get; set; }
        public string NamaNotaris { get; set; }
        public string NamaSkMenteri { get; set; }
        public string NoAkta { get; set; }
        public DateTime? TglAkta { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
    public partial class VendorLandasanHukumRequest
    {
        [Required]
        public int CivdId { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string FileLandasanHukum { get; set; }
        public string FileLandasanHukumId { get; set; }
        public Guid? IdVendor { get; set; }
        public string JenisAkta { get; set; }
        public string NamaNotaris { get; set; }
        public string NamaSkMenteri { get; set; }
        public string NoAkta { get; set; }
        public DateTime? TglAkta { get; set; }

    }
    public interface IVendorLandasanHukumService
    {
        Task<ObjectResponse<VendorLandasanHukumResponse>> Get(Guid id, string baseUrl, string token);
        Task<ListResponse<VendorLandasanHukumResponse>> List(ListRequest request, string baseUrl, string token);
        Task<StatusResponse> Add(VendorLandasanHukumRequest request, string baseUrl, string token);
        Task<StatusResponse> Edit(Guid id, VendorLandasanHukumRequest request, string baseUrl, string token);
        Task<StatusResponse> Delete(Guid id, string baseUrl, string token);

    }
    public class VendorLandasanHukumService : IVendorLandasanHukumService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public VendorLandasanHukumService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<VendorLandasanHukumResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<VendorLandasanHukumResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/VendorLandasanHukum/get/{id}", null));
        }
        
        public async Task<ListResponse<VendorLandasanHukumResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<VendorLandasanHukumResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorLandasanHukum/list", request));
        }
        
        public async Task<StatusResponse> Add(VendorLandasanHukumRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorLandasanHukum/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, VendorLandasanHukumRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/VendorLandasanHukum/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/VendorLandasanHukum/delete/{id}", null));
        }
        
    }
}

