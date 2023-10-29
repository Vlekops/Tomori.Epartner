namespace Tomori.Epartner.Web.Component.Services
{
    public class WorkflowConfigDetailService : IWorkflowConfigDetailService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public WorkflowConfigDetailService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<WorkflowConfigDetailResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<WorkflowConfigDetailResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/WorkflowConfigDetail/get/{id}", null));
        }
        
        public async Task<ListResponse<WorkflowConfigDetailResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<WorkflowConfigDetailResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/WorkflowConfigDetail/list", request));
        }
        
        public async Task<StatusResponse> Add(WorkflowConfigDetailRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/WorkflowConfigDetail/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, WorkflowConfigDetailRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/WorkflowConfigDetail/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/WorkflowConfigDetail/delete/{id}", null));
        }
        
    }
}

