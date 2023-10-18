namespace Tomori.Epartner.Web.Component.Services
{
    public class NotificationService : INotificationService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public NotificationService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<NotificationResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<NotificationResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/Notification/get/{id}", null));
        }
        
        public async Task<ListResponse<NotificationResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<NotificationResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/Notification/list", request));
        }
        
        public async Task<StatusResponse> Add(NotificationRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/Notification/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, NotificationRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/Notification/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/Notification/delete/{id}", null));
        }
        
    }
}

