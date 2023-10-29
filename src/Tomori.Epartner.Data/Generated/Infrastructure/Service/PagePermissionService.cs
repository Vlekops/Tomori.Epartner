namespace Tomori.Epartner.Web.Component.Services
{
    public class PagePermissionService : IPagePermissionService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public PagePermissionService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<PagePermissionResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<PagePermissionResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/PagePermission/get/{id}", null));
        }
        
        public async Task<ListResponse<PagePermissionResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<PagePermissionResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/PagePermission/list", request));
        }
        
        public async Task<StatusResponse> Add(PagePermissionRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/PagePermission/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, PagePermissionRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/PagePermission/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/PagePermission/delete/{id}", null));
        }
        
        public async Task<StatusResponse> Active(Guid id, bool value, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/PagePermission/active/{id}/{value}", null));
        }
        
    }
}

