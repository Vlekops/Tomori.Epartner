namespace Tomori.Epartner.Web.Component.Services
{
    public class WorkflowService : IWorkflowService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public WorkflowService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<WorkflowResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<WorkflowResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/Workflow/get/{id}", null));
        }
        
        public async Task<ListResponse<WorkflowResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<WorkflowResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/Workflow/list", request));
        }
        
        public async Task<StatusResponse> Add(WorkflowRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/Workflow/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, WorkflowRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/Workflow/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/Workflow/delete/{id}", null));
        }
        
    }
}

