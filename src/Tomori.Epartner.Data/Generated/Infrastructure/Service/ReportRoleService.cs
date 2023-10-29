namespace Tomori.Epartner.Web.Component.Services
{
    public class ReportRoleService : IReportRoleService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public ReportRoleService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<ReportRoleResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<ReportRoleResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/ReportRole/get/{id}", null));
        }
        
        public async Task<ListResponse<ReportRoleResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<ReportRoleResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/ReportRole/list", request));
        }
        
        public async Task<StatusResponse> Add(ReportRoleRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/ReportRole/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, ReportRoleRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/ReportRole/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/ReportRole/delete/{id}", null));
        }
        
    }
}

