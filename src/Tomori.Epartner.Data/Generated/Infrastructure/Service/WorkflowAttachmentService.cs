namespace Tomori.Epartner.Web.Component.Services
{
    public class WorkflowAttachmentService : IWorkflowAttachmentService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public WorkflowAttachmentService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<WorkflowAttachmentResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<WorkflowAttachmentResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/WorkflowAttachment/get/{id}", null));
        }
        
        public async Task<ListResponse<WorkflowAttachmentResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<WorkflowAttachmentResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/WorkflowAttachment/list", request));
        }
        
        public async Task<StatusResponse> Add(WorkflowAttachmentRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/WorkflowAttachment/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, WorkflowAttachmentRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/WorkflowAttachment/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/WorkflowAttachment/delete/{id}", null));
        }
        
    }
}

