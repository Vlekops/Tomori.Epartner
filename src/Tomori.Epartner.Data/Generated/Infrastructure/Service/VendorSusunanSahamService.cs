namespace Tomori.Epartner.Web.Component.Services
{
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

