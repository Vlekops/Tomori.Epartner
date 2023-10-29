using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class WorkflowConfigResponse
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public bool IsSequence { get; set; }
        public string CallbackUrl { get; set; }
        public string Code { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
        public string NavigationUrl { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
    public partial class WorkflowConfigRequest
    {
        [Required]
        public bool Active { get; set; }
        public string CallbackUrl { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsSequence { get; set; }
        public string NavigationUrl { get; set; }

    }
    public interface IWorkflowConfigService
    {
        Task<ObjectResponse<WorkflowConfigResponse>> Get(Guid id, string baseUrl, string token);
        Task<ListResponse<WorkflowConfigResponse>> List(ListRequest request, string baseUrl, string token);
        Task<StatusResponse> Add(WorkflowConfigRequest request, string baseUrl, string token);
        Task<StatusResponse> Edit(Guid id, WorkflowConfigRequest request, string baseUrl, string token);
        Task<StatusResponse> Delete(Guid id, string baseUrl, string token);

    }
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
        
    }
}

