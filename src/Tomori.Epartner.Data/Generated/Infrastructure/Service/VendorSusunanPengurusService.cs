namespace Tomori.Epartner.Web.Component.Services
{
    public class VendorSusunanPengurusService : IVendorSusunanPengurusService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public VendorSusunanPengurusService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<VendorSusunanPengurusResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<VendorSusunanPengurusResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/VendorSusunanPengurus/get/{id}", null));
        }
        
        public async Task<ListResponse<VendorSusunanPengurusResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<VendorSusunanPengurusResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorSusunanPengurus/list", request));
        }
        
        public async Task<StatusResponse> Add(VendorSusunanPengurusRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorSusunanPengurus/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, VendorSusunanPengurusRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/VendorSusunanPengurus/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/VendorSusunanPengurus/delete/{id}", null));
        }
        
    }
}

