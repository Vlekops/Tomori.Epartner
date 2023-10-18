namespace Tomori.Epartner.Web.Component.Services
{
    #region Request
    public class PageRequest
    {
        public bool Active { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public Guid? IdParent { get; set; }
        public string Name { get; set; }
        public string Navigation { get; set; }
        public string Section { get; set; }
        public int Sort { get; set; }
    }
    #endregion

    #region Response
    public class PageResponse
    {
        public Guid Id { get; set; }
        public Guid? IdParent { get; set; }
        public string Section { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Navigation { get; set; }
        public int Sort { get; set; }
        public bool Active { get; set; }
        public List<string> Permission { get; set; }
        public List<PageResponse> Childs { get; set; } = new List<PageResponse>();
    }

    public class PageByRoleResponse
    {
        public Guid IdPage { get; set; }
        public string Section { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public List<RolePermissionResponse> Permissions { get; set; } = new List<RolePermissionResponse>();
    }
    #endregion

    #region Service
    public interface IPageService
    {
        Task<ListResponse<PageResponse>> GetByUser(string baseUrl, string token);
        Task<ListResponse<PageByRoleResponse>> GetByRole(string idRole, string search, int? start, int? length, string baseUrl, string token);
        Task<ListResponse<PageResponse>> Get(string search, int? start, int? length, string baseUrl, string token);
        Task<ListResponse<PageResponse>> List(ListRequest request, string baseUrl, string token);
        Task<StatusResponse> Add(PageRequest request, string baseUrl, string token);
        Task<StatusResponse> Edit(Guid id, PageRequest request, string baseUrl, string token);
        Task<StatusResponse> Delete(Guid id, string baseUrl, string token);
        Task<StatusResponse> Active(Guid id, bool value, string baseUrl, string token);
    }

    public class PageService : IPageService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;
        public PageService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ListResponse<PageResponse>> GetByUser(string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<PageResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/Page/get_by_user", null));
        }

        public async Task<ListResponse<PageByRoleResponse>> GetByRole(string idRole, string search, int? start, int? length, string baseUrl, string token)
        {
            string param = string.Empty;
            if (!string.IsNullOrEmpty(search))
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}search={search}";

            if (start.HasValue)
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}start={start.Value}";

            if (length.HasValue)
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}length={length.Value}";

            param = $"{baseUrl}/v1/Page/get_by_role/{idRole}{(string.IsNullOrEmpty(param) ? string.Empty : $"?{param}")}";

            return _request.Response(await _request.DoRequest<ListResponse<PageByRoleResponse>>(HttpMethod.Get, token, param, null));
        }

        public async Task<ListResponse<PageResponse>> Get(string search, int? start, int? length, string baseUrl, string token)
        {
            string param = string.Empty;
            if (!string.IsNullOrEmpty(search))
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}search={search}";

            if (start.HasValue)
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}start={start.Value}";

            if (length.HasValue)
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}length={length.Value}";

            return _request.Response(await _request.DoRequest<ListResponse<PageResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/Page/get{(string.IsNullOrEmpty(param) ? string.Empty : $"?{param}")}", null));
        }
        public async Task<ListResponse<PageResponse>> List(ListRequest request, string baseUrl, string token)
        {
            var tes = await _request.RefreshToken();
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

        public async Task<StatusResponse> Delete(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/Page/delete/{id}", null));
        }

        public async Task<StatusResponse> Active(Guid id, bool value, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/Page/active/{id}/{value}", null));
        }
    }
    #endregion

}
