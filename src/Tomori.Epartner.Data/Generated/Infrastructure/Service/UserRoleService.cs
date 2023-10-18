namespace Tomori.Epartner.Web.Component.Services
{
    public class UserRoleService : IUserRoleService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public UserRoleService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<UserRoleResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<UserRoleResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/UserRole/get/{id}", null));
        }
        
        public async Task<ListResponse<UserRoleResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<UserRoleResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/UserRole/list", request));
        }
        
        public async Task<StatusResponse> Add(UserRoleRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/UserRole/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, UserRoleRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/UserRole/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/UserRole/delete/{id}", null));
        }
        
    }
}

