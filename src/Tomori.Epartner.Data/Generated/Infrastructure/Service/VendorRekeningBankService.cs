namespace Tomori.Epartner.Web.Component.Services
{
    public class VendorRekeningBankService : IVendorRekeningBankService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public VendorRekeningBankService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<VendorRekeningBankResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<VendorRekeningBankResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/VendorRekeningBank/get/{id}", null));
        }
        
        public async Task<ListResponse<VendorRekeningBankResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<VendorRekeningBankResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorRekeningBank/list", request));
        }
        
        public async Task<StatusResponse> Add(VendorRekeningBankRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorRekeningBank/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, VendorRekeningBankRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/VendorRekeningBank/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/VendorRekeningBank/delete/{id}", null));
        }
        
    }
}

