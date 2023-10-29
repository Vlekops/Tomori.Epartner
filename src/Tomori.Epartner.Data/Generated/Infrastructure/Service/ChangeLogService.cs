namespace Tomori.Epartner.Web.Component.Services
{
    public class ChangeLogService : IChangeLogService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public ChangeLogService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<ChangeLogResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<ChangeLogResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/ChangeLog/get/{id}", null));
        }
        
        public async Task<ListResponse<ChangeLogResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<ChangeLogResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/ChangeLog/list", request));
        }
        
        public async Task<StatusResponse> Add(ChangeLogRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/ChangeLog/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, ChangeLogRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/ChangeLog/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/ChangeLog/delete/{id}", null));
        }
        
    }
}

