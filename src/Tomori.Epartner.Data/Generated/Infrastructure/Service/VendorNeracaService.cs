namespace Tomori.Epartner.Web.Component.Services
{
    public class VendorNeracaService : IVendorNeracaService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public VendorNeracaService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<VendorNeracaResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<VendorNeracaResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/VendorNeraca/get/{id}", null));
        }
        
        public async Task<ListResponse<VendorNeracaResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<VendorNeracaResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorNeraca/list", request));
        }
        
        public async Task<StatusResponse> Add(VendorNeracaRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorNeraca/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, VendorNeracaRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/VendorNeraca/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/VendorNeraca/delete/{id}", null));
        }
        
    }
}

