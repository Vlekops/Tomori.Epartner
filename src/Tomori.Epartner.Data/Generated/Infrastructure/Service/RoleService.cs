namespace Tomori.Epartner.Web.Component.Services
{
    public class RoleService : IRoleService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public RoleService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<RoleResponse>> Get(string id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<RoleResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/Role/get/{id}", null));
        }
        
        public async Task<ListResponse<RoleResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<RoleResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/Role/list", request));
        }
        
        public async Task<StatusResponse> Add(RoleRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/Role/add", request));
        }
        
        public async Task<StatusResponse> Edit(string id, RoleRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/Role/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (string id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/Role/delete/{id}", null));
        }
        
        public async Task<StatusResponse> Active(string id, bool value, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/Role/active/{id}/{value}", null));
        }
        
    }
}

