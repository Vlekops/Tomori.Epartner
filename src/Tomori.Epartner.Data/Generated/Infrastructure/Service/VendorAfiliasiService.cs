namespace Tomori.Epartner.Web.Component.Services
{
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

