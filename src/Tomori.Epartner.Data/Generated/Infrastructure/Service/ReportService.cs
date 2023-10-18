namespace Tomori.Epartner.Web.Component.Services
{
    public class ReportService : IReportService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public ReportService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<ReportResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<ReportResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/Report/get/{id}", null));
        }
        
        public async Task<ListResponse<ReportResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<ReportResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/Report/list", request));
        }
        
        public async Task<StatusResponse> Add(ReportRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/Report/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, ReportRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/Report/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/Report/delete/{id}", null));
        }
        
        public async Task<StatusResponse> Active(Guid id, bool value, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/Report/active/{id}/{value}", null));
        }
        
    }
}

