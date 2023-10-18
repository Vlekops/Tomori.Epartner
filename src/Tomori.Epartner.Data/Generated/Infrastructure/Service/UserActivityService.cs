namespace Tomori.Epartner.Web.Component.Services
{
    public class UserActivityService : IUserActivityService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public UserActivityService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<UserActivityResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<UserActivityResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/UserActivity/get/{id}", null));
        }
        
        public async Task<ListResponse<UserActivityResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<UserActivityResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/UserActivity/list", request));
        }
        
        public async Task<StatusResponse> Add(UserActivityRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/UserActivity/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, UserActivityRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/UserActivity/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/UserActivity/delete/{id}", null));
        }
        
    }
}

