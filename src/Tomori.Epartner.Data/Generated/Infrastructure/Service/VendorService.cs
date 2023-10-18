namespace Tomori.Epartner.Web.Component.Services
{
    public class VendorService : IVendorService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public VendorService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<VendorResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<VendorResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/Vendor/get/{id}", null));
        }
        
        public async Task<ListResponse<VendorResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<VendorResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/Vendor/list", request));
        }
        
        public async Task<StatusResponse> Add(VendorRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/Vendor/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, VendorRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/Vendor/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/Vendor/delete/{id}", null));
        }
        
    }
}

