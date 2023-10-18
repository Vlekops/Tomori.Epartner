namespace Tomori.Epartner.Web.Component.Services
{
    public class WorkflowDetailService : IWorkflowDetailService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public WorkflowDetailService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<WorkflowDetailResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<WorkflowDetailResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/WorkflowDetail/get/{id}", null));
        }
        
        public async Task<ListResponse<WorkflowDetailResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<WorkflowDetailResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/WorkflowDetail/list", request));
        }
        
        public async Task<StatusResponse> Add(WorkflowDetailRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/WorkflowDetail/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, WorkflowDetailRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/WorkflowDetail/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/WorkflowDetail/delete/{id}", null));
        }
        
    }
}

