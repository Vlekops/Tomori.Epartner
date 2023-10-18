namespace Tomori.Epartner.Web.Component.Services
{
    public class ChangeLogPropertyService : IChangeLogPropertyService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public ChangeLogPropertyService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<ChangeLogPropertyResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<ChangeLogPropertyResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/ChangeLogProperty/get/{id}", null));
        }
        
        public async Task<ListResponse<ChangeLogPropertyResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<ChangeLogPropertyResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/ChangeLogProperty/list", request));
        }
        
        public async Task<StatusResponse> Add(ChangeLogPropertyRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/ChangeLogProperty/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, ChangeLogPropertyRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/ChangeLogProperty/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/ChangeLogProperty/delete/{id}", null));
        }
        
    }
}

