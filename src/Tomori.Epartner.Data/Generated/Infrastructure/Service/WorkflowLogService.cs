namespace Tomori.Epartner.Web.Component.Services
{
    public class WorkflowLogService : IWorkflowLogService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public WorkflowLogService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<WorkflowLogResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<WorkflowLogResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/WorkflowLog/get/{id}", null));
        }
        
        public async Task<ListResponse<WorkflowLogResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<WorkflowLogResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/WorkflowLog/list", request));
        }
        
        public async Task<StatusResponse> Add(WorkflowLogRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/WorkflowLog/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, WorkflowLogRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/WorkflowLog/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/WorkflowLog/delete/{id}", null));
        }
        
    }
}

