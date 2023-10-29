namespace Tomori.Epartner.Web.Component.Services
{
    public class UserPasswordService : IUserPasswordService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public UserPasswordService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<UserPasswordResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<UserPasswordResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/UserPassword/get/{id}", null));
        }
        
        public async Task<ListResponse<UserPasswordResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<UserPasswordResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/UserPassword/list", request));
        }
        
        public async Task<StatusResponse> Add(UserPasswordRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/UserPassword/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, UserPasswordRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/UserPassword/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/UserPassword/delete/{id}", null));
        }
        
    }
}

