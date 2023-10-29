namespace Tomori.Epartner.Web.Component.Services
{
    public class VendorIzinUsahaService : IVendorIzinUsahaService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public VendorIzinUsahaService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<VendorIzinUsahaResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<VendorIzinUsahaResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/VendorIzinUsaha/get/{id}", null));
        }
        
        public async Task<ListResponse<VendorIzinUsahaResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<VendorIzinUsahaResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorIzinUsaha/list", request));
        }
        
        public async Task<StatusResponse> Add(VendorIzinUsahaRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorIzinUsaha/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, VendorIzinUsahaRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/VendorIzinUsaha/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/VendorIzinUsaha/delete/{id}", null));
        }
        
    }
}

