namespace Tomori.Epartner.Web.Component.Services
{
    public class UserService : IUserService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public UserService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<UserResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<UserResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/User/get/{id}", null));
        }
        
        public async Task<ListResponse<UserResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<UserResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/User/list", request));
        }
        
        public async Task<StatusResponse> Add(UserRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/User/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, UserRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/User/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/User/delete/{id}", null));
        }
        
        public async Task<StatusResponse> Active(Guid id, bool value, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/User/active/{id}/{value}", null));
        }
        
    }
}

