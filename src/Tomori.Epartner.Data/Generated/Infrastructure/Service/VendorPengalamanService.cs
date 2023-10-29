namespace Tomori.Epartner.Web.Component.Services
{
    public class VendorPengalamanService : IVendorPengalamanService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public VendorPengalamanService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<VendorPengalamanResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<VendorPengalamanResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/VendorPengalaman/get/{id}", null));
        }
        
        public async Task<ListResponse<VendorPengalamanResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<VendorPengalamanResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorPengalaman/list", request));
        }
        
        public async Task<StatusResponse> Add(VendorPengalamanRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorPengalaman/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, VendorPengalamanRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/VendorPengalaman/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/VendorPengalaman/delete/{id}", null));
        }
        
    }
}

