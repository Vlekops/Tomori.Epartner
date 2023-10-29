namespace Tomori.Epartner.Web.Component.Services
{
    public class VendorKompetensiService : IVendorKompetensiService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public VendorKompetensiService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<VendorKompetensiResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<VendorKompetensiResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/VendorKompetensi/get/{id}", null));
        }
        
        public async Task<ListResponse<VendorKompetensiResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<VendorKompetensiResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorKompetensi/list", request));
        }
        
        public async Task<StatusResponse> Add(VendorKompetensiRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorKompetensi/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, VendorKompetensiRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/VendorKompetensi/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/VendorKompetensi/delete/{id}", null));
        }
        
    }
}

