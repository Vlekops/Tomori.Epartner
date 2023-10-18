namespace Tomori.Epartner.Web.Component.Services
{
    public class WorkflowConfigService : IWorkflowConfigService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public WorkflowConfigService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<WorkflowConfigResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<WorkflowConfigResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/WorkflowConfig/get/{id}", null));
        }
        
        public async Task<ListResponse<WorkflowConfigResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<WorkflowConfigResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/WorkflowConfig/list", request));
        }
        
        public async Task<StatusResponse> Add(WorkflowConfigRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/WorkflowConfig/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, WorkflowConfigRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/WorkflowConfig/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/WorkflowConfig/delete/{id}", null));
        }
        
        public async Task<StatusResponse> Active(Guid id, bool value, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/WorkflowConfig/active/{id}/{value}", null));
        }
        
    }
}

