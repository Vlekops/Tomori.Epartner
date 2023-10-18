namespace Tomori.Epartner.Web.Component.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public AnnouncementService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<AnnouncementResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<AnnouncementResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/Announcement/get/{id}", null));
        }
        
        public async Task<ListResponse<AnnouncementResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<AnnouncementResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/Announcement/list", request));
        }
        
        public async Task<StatusResponse> Add(AnnouncementRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/Announcement/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, AnnouncementRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/Announcement/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/Announcement/delete/{id}", null));
        }
        
    }
}

