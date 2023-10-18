namespace Tomori.Epartner.Web.Component.Services
{
    public class VendorSanksiService : IVendorSanksiService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public VendorSanksiService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<VendorSanksiResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<VendorSanksiResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/VendorSanksi/get/{id}", null));
        }
        
        public async Task<ListResponse<VendorSanksiResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<VendorSanksiResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorSanksi/list", request));
        }
        
        public async Task<StatusResponse> Add(VendorSanksiRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorSanksi/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, VendorSanksiRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/VendorSanksi/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/VendorSanksi/delete/{id}", null));
        }
        
    }
}

