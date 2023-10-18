namespace Tomori.Epartner.Web.Component.Services
{
    public class ApiLogService : IApiLogService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public ApiLogService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<ApiLogResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<ApiLogResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/ApiLog/get/{id}", null));
        }
        
        public async Task<ListResponse<ApiLogResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<ApiLogResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/ApiLog/list", request));
        }
        
        public async Task<StatusResponse> Add(ApiLogRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/ApiLog/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, ApiLogRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/ApiLog/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/ApiLog/delete/{id}", null));
        }
        
    }
}

