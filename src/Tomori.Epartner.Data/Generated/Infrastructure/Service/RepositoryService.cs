namespace Tomori.Epartner.Web.Component.Services
{
    public class RepositoryService : IRepositoryService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public RepositoryService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<RepositoryResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<RepositoryResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/Repository/get/{id}", null));
        }
        
        public async Task<ListResponse<RepositoryResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<RepositoryResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/Repository/list", request));
        }
        
        public async Task<StatusResponse> Add(RepositoryRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/Repository/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, RepositoryRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/Repository/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/Repository/delete/{id}", null));
        }
        
    }
}

