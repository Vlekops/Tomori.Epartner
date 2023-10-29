namespace Tomori.Epartner.Web.Component.Services
{
    #region Request
    public class PagePermissionRequest
    {
        public bool Active { get; set; }
        public Guid IdPage { get; set; }
        public string Name { get; set; }

    }
    #endregion

    #region Response
    public class PagePermissionResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public PageResponse Page { get; set; }
    }
    #endregion

    public interface IPagePermissionService
    {
        Task<ListResponse<PagePermissionResponse>> Get(Guid id,int?start,int? length, string baseUrl, string token);
        Task<ListResponse<PagePermissionResponse>> List(ListRequest request, string baseUrl, string token);
        Task<StatusResponse> Add(PagePermissionRequest request, string baseUrl, string token);
        Task<StatusResponse> Edit(Guid id, PagePermissionRequest request, string baseUrl, string token);
        Task<StatusResponse> Delete(Guid id, string baseUrl, string token);
        Task<StatusResponse> Active(Guid id, bool value, string baseUrl, string token);
    }

    public class PagePermissionService : IPagePermissionService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public PagePermissionService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ListResponse<PagePermissionResponse>> Get(Guid id, int? start, int? length, string baseUrl, string token)
        {
            string param = string.Empty;

            if (start.HasValue)
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}start={start.Value}";

            if (length.HasValue)
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}length={length.Value}";

            return _request.Response(await _request.DoRequest<ListResponse<PagePermissionResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/PagePermission/get/{id}{(string.IsNullOrEmpty(param) ? string.Empty : $"?{param}")}", null));
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

        public async Task<StatusResponse> Delete(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/PagePermission/delete/{id}", null));
        }

        public async Task<StatusResponse> Active(Guid id, bool value, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/PagePermission/active/{id}/{value}", null));
        }
    }
}
