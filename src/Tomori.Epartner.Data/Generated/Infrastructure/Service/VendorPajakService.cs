namespace Tomori.Epartner.Web.Component.Services
{
    public class VendorPajakService : IVendorPajakService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public VendorPajakService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<VendorPajakResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<VendorPajakResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/VendorPajak/get/{id}", null));
        }
        
        public async Task<ListResponse<VendorPajakResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<VendorPajakResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorPajak/list", request));
        }
        
        public async Task<StatusResponse> Add(VendorPajakRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorPajak/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, VendorPajakRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/VendorPajak/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/VendorPajak/delete/{id}", null));
        }
        
    }
}

