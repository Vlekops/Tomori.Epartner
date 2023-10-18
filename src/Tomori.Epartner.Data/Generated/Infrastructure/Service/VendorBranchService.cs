namespace Tomori.Epartner.Web.Component.Services
{
    public class VendorBranchService : IVendorBranchService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public VendorBranchService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<VendorBranchResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<VendorBranchResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/VendorBranch/get/{id}", null));
        }
        
        public async Task<ListResponse<VendorBranchResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<VendorBranchResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorBranch/list", request));
        }
        
        public async Task<StatusResponse> Add(VendorBranchRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorBranch/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, VendorBranchRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/VendorBranch/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/VendorBranch/delete/{id}", null));
        }
        
    }
}

