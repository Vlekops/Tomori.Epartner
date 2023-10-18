namespace Tomori.Epartner.Web.Component.Services
{
    public class RolePermissionService : IRolePermissionService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public RolePermissionService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<RolePermissionResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<RolePermissionResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/RolePermission/get/{id}", null));
        }
        
        public async Task<ListResponse<RolePermissionResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<RolePermissionResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/RolePermission/list", request));
        }
        
        public async Task<StatusResponse> Add(RolePermissionRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/RolePermission/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, RolePermissionRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/RolePermission/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/RolePermission/delete/{id}", null));
        }
        
    }
}

