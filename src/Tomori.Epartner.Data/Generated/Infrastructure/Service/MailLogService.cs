namespace Tomori.Epartner.Web.Component.Services
{
    public class MailLogService : IMailLogService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public MailLogService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<MailLogResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<MailLogResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/MailLog/get/{id}", null));
        }
        
        public async Task<ListResponse<MailLogResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<MailLogResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/MailLog/list", request));
        }
        
        public async Task<StatusResponse> Add(MailLogRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/MailLog/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, MailLogRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/MailLog/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/MailLog/delete/{id}", null));
        }
        
    }
}

