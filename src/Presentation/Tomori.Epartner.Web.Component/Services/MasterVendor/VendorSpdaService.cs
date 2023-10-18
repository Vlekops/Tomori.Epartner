namespace Tomori.Epartner.Web.Component.Services
{
    public partial class VendorSpdaResponse
    {
        public Guid Id { get; set; }
        public int CivdId { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public string FileSpda { get; set; }
        public string FileSpdaId { get; set; }
        public Guid? IdVendor { get; set; }
        public string SpdaNo { get; set; }
        public string SpdaValidity { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? UploadDate { get; set; }

    }
    public partial class VendorSpdaRequest
    {
        [Required]
        public int CivdId { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public string FileSpda { get; set; }
        public string FileSpdaId { get; set; }
        public Guid? IdVendor { get; set; }
        public string SpdaNo { get; set; }
        public string SpdaValidity { get; set; }
        public DateTime? UploadDate { get; set; }

    }
    public interface IVendorSpdaService
    {
        Task<ObjectResponse<VendorSpdaResponse>> Get(Guid id, string baseUrl, string token);
        Task<ListResponse<VendorSpdaResponse>> List(ListRequest request, string baseUrl, string token);
        Task<StatusResponse> Add(VendorSpdaRequest request, string baseUrl, string token);
        Task<StatusResponse> Edit(Guid id, VendorSpdaRequest request, string baseUrl, string token);
        Task<StatusResponse> Delete(Guid id, string baseUrl, string token);

    }
    public class VendorSpdaService : IVendorSpdaService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public VendorSpdaService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<VendorSpdaResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<VendorSpdaResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/VendorSpda/get/{id}", null));
        }
        
        public async Task<ListResponse<VendorSpdaResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<VendorSpdaResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorSpda/list", request));
        }
        
        public async Task<StatusResponse> Add(VendorSpdaRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorSpda/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, VendorSpdaRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/VendorSpda/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/VendorSpda/delete/{id}", null));
        }
        
    }
}

