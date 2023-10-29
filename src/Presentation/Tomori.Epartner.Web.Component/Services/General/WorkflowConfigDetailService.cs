using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class WorkflowConfigDetailResponse
    {
        public Guid Id { get; set; }
        public DateTime? AutoApproveExpired { get; set; }
        public bool CanAdhoc { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public MiniUserResponse User { get; set; }
        public Guid IdWorkflowConfig { get; set; }
        public bool IsReviewer { get; set; }
        public string StepName { get; set; }
        public int StepNo { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
    public partial class WorkflowConfigDetailRequest
    {
        public DateTime? AutoApproveExpired { get; set; }
        [Required]
        public bool CanAdhoc { get; set; }
        [Required]
        public Guid IdUser { get; set; }
        [Required]
        public Guid IdWorkflowConfig { get; set; }
        [Required]
        public bool IsReviewer { get; set; }
        [Required]
        public string StepName { get; set; }
        [Required]
        public int StepNo { get; set; }

    }
    public interface IWorkflowConfigDetailService
    {
        Task<ObjectResponse<WorkflowConfigDetailResponse>> Get(Guid id, string baseUrl, string token);
        Task<ListResponse<WorkflowConfigDetailResponse>> List(ListRequest request, string baseUrl, string token);
        Task<StatusResponse> Add(WorkflowConfigDetailRequest request, string baseUrl, string token);
        Task<StatusResponse> Edit(Guid id, WorkflowConfigDetailRequest request, string baseUrl, string token);
        Task<StatusResponse> Delete(Guid id, string baseUrl, string token);

    }
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

