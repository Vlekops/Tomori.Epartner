namespace Tomori.Epartner.Web.Component.Services
{
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

