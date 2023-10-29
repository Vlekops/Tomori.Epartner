namespace Tomori.Epartner.Web.Component.Services
{
    public partial class VendorAfiliasiResponse
    {
        public Guid Id { get; set; }
        public int CivdId { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string Deskripsi { get; set; }
        public string FileAfiliasiId { get; set; }
        public Guid? IdVendor { get; set; }
        public decimal? Share { get; set; }
        public string Terafiliasi { get; set; }
        public string TipeAfiliasi { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
    public partial class VendorAfiliasiRequest
    {
        [Required]
        public int CivdId { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string Deskripsi { get; set; }
        public string FileAfiliasiId { get; set; }
        public Guid? IdVendor { get; set; }
        public decimal? Share { get; set; }
        public string Terafiliasi { get; set; }
        public string TipeAfiliasi { get; set; }

    }
    public interface IVendorAfiliasiService
    {
        Task<ObjectResponse<VendorAfiliasiResponse>> Get(Guid id, string baseUrl, string token);
        Task<ListResponse<VendorAfiliasiResponse>> List(ListRequest request, string baseUrl, string token);
        Task<StatusResponse> Add(VendorAfiliasiRequest request, string baseUrl, string token);
        Task<StatusResponse> Edit(Guid id, VendorAfiliasiRequest request, string baseUrl, string token);
        Task<StatusResponse> Delete(Guid id, string baseUrl, string token);

    }
    public class VendorAfiliasiService : IVendorAfiliasiService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public VendorAfiliasiService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<VendorAfiliasiResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<VendorAfiliasiResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/VendorAfiliasi/get/{id}", null));
        }
        
        public async Task<ListResponse<VendorAfiliasiResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<VendorAfiliasiResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorAfiliasi/list", request));
        }
        
        public async Task<StatusResponse> Add(VendorAfiliasiRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorAfiliasi/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, VendorAfiliasiRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/VendorAfiliasi/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/VendorAfiliasi/delete/{id}", null));
        }
        
    }
}

