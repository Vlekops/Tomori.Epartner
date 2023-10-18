namespace Tomori.Epartner.Web.Component.Services
{
    public class PageService : IPageService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public PageService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<PageResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<PageResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/Page/get/{id}", null));
        }
        
        public async Task<ListResponse<PageResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<PageResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/Page/list", request));
        }
        
        public async Task<StatusResponse> Add(PageRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/Page/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, PageRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/Page/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/Page/delete/{id}", null));
        }
        
        public async Task<StatusResponse> Active(Guid id, bool value, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/Page/active/{id}/{value}", null));
        }
        
    }
}

