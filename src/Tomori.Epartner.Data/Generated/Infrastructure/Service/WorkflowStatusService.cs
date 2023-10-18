namespace Tomori.Epartner.Web.Component.Services
{
    public class WorkflowStatusService : IWorkflowStatusService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public WorkflowStatusService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<WorkflowStatusResponse>> Get(short id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<WorkflowStatusResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/WorkflowStatus/get/{id}", null));
        }
        
        public async Task<ListResponse<WorkflowStatusResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<WorkflowStatusResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/WorkflowStatus/list", request));
        }
        
        public async Task<StatusResponse> Add(WorkflowStatusRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/WorkflowStatus/add", request));
        }
        
        public async Task<StatusResponse> Edit(short id, WorkflowStatusRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/WorkflowStatus/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (short id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/WorkflowStatus/delete/{id}", null));
        }
        
        public async Task<StatusResponse> Active(short id, bool value, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/WorkflowStatus/active/{id}/{value}", null));
        }
        
    }
}

