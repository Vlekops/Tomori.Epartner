namespace Tomori.Epartner.Web.Component.Services
{
    public class UserDelegateService : IUserDelegateService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public UserDelegateService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<UserDelegateResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<UserDelegateResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/UserDelegate/get/{id}", null));
        }
        
        public async Task<ListResponse<UserDelegateResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<UserDelegateResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/UserDelegate/list", request));
        }
        
        public async Task<StatusResponse> Add(UserDelegateRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/UserDelegate/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, UserDelegateRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/UserDelegate/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/UserDelegate/delete/{id}", null));
        }
        
    }
}

