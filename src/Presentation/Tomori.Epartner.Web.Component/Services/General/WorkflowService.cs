namespace Tomori.Epartner.Web.Component.Services
{
    #region Workflow Attachment
    public class WorkflowAttachmentResponse
    {
        public Guid Id { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid IdRepository { get; set; }
        public Guid IdWorkflow { get; set; }
        public FileObject File { get; set; }
    }
    #endregion

    #region Request
    public class WorkflowDetailRequest
    {
        public string Code { get; set; }
        public List<string> WorkflowCode { get; set; }
    }
    #endregion

    #region Response
    public enum WorkflowStatusEnum
    {
        Waiting = 0,
        Request = 1,
        Review = 2,
        Approve = 3,
        Approve_Parallel = 4,
        Reject = 5,
        Reject_Parallel = 6,
        Adhoc = 7,
        Delegasi = 8,
    }

    public enum WorkflowEnum
    {
        Process,
        Reject,
        Approved
    }

    public class WorkflowHistoryResponse
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string WorkflowCode { get; set; }
        public string DocumentNo { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public string NavigationUrl { get; set; }
        public WorkflowStatusEnum Status { get; set; }
        public string StatusDescription { get; set; }
        public DateTime CreateDate { get; set; }
        public string FullnameRequester { get; set; }
    }
    public class WorkflowTaskResponse
    {
        public Guid Id { get; set; }
        public string DocumentNo { get; set; }
        public string Code { get; set; }
        public string WorkflowCode { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public int GroupNo { get; set; }
        public int StepNo { get; set; }
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }

        public string NavigationUrl { get; set; }
        public List<string> NextApprover { get; set; }

        public Guid IdUserRequester { get; set; }
        public string EmailRequester { get; set; }
        public string FullnameRequester { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
    }
    public class WorkflowCheckObject
    {
        public bool IsReviewer { get; set; }
        public bool IsAdhoc { get; set; }
        public bool CanAdhoc { get; set; }
    }
    public class WorkflowAttachmentObject
    {
        public Guid IdRepository { get; set; }
        public string Filename { get; set; }
        public string Description { get; set; }
    }
    public class WorkflowDetailResponse
    {
        public Guid IdWorkflow { get; set; }
        public string Code { get; set; }
        public string WorkflowCode { get; set; }
        public WorkflowCheckObject Approval { get; set; }
        public List<WorkflowObject> Workflow { get; set; }
    }
    public class WorkflowObject
    {
        public Guid Id { get; set; }
        public bool CurrentWorkflow { get; set; }
        public string WorkflowCode { get; set; }
        public string DocumentNo { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Data { get; set; }
        public List<WorkflowAttachmentObject> Attachment { get; set; }
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public Guid IdUserRequester { get; set; }
        public string EmailRequester { get; set; }
        public string FullnameRequester { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public List<WorkflowDetailObject> Detail { get; set; }
    }
    public class WorkflowDetailObject
    {
        public Guid Id { get; set; }
        public int GroupNo { get; set; }
        public int StepNo { get; set; }
        public string StepName { get; set; }
        public bool CurrentStep { get; set; }
        public Guid IdUser { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public bool IsAdhoc { get; set; }
        public bool IsReviewer { get; set; }
        public string Notes { get; set; }
        public WorkflowStatusEnum Status { get; set; }
        public string StatusDescription { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class WorkflowResponse
    {
        public Guid Id { get; set; }
        public string CallbackUrl { get; set; }
        public string Code { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string DataWorkflow { get; set; }
        public string Description { get; set; }
        public string DocumentNo { get; set; }
        public string EmailRequester { get; set; }
        public string FullnameRequester { get; set; }
        public int GroupNo { get; set; }
        public Guid IdUserRequester { get; set; }
        public string NavigationUrl { get; set; }
        public WorkflowEnum StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public int StepNo { get; set; }
        public string Subject { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string WorkflowCode { get; set; }
        public List<WorkflowAttachmentResponse> Attachments { get; set; } = new List<WorkflowAttachmentResponse>();
        public List<string> NextApprover { get; set; }
    }
    #endregion

    #region Request
    public partial class RequestWorkflowRequest
    {
        public string Code { get; set; }
        public string WorkflowCode { get; set; }
        public string Subject { get; set; }
        public string DocumentNo { get; set; }
        public string Description { get; set; }
        public string Data { get; set; }
        public List<FileObject> Attachment { get; set; }
    }

    public partial class ApprovalWorkflowRequest
    {
        public Guid IdWorkflow { get; set; }
        public bool IsApprove { get; set; }
        public string Notes { get; set; }
    }

    public partial class DelegateWorkflowRequest
    {
        public Guid IdWorkflow { get; set; }
        public Guid IdUser { get; set; }
        public DelegateTipeEnum Tipe { get; set; }
        public string Message { get; set; }
    }

    public enum DelegateTipeEnum
    {
        Reviewer,
        Delegate,
        Adhoc
    }

    public class WorkflowUpdateDataHistoryResponse
    {
        public Guid WorkflowId { get; set; }
        public WorkflowEnum Status { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid DokumenPendukungId { get; set; }
        public string DokumenPendukungName { get; set; }
        public string Data { get; set; }
        public string Notes { get; set; }
    }
    #endregion

    public interface IWorkflowService
    {
        Task<ObjectResponse<WorkflowDetailResponse>> Detail(WorkflowDetailRequest request, string baseUrl, string token);
        Task<ListResponse<WorkflowTaskResponse>> Task(string workflow_code, int? start, int? length, string baseUrl, string token);
        Task<ListResponse<WorkflowHistoryResponse>> History(string workflow_code, int? start, int? length, string baseUrl, string token);
        Task<ListResponse<WorkflowResponse>> List(ListRequest request, string baseUrl, string token);
        Task<ListResponse<WorkflowHistoryResponse>> HistoryOther(ListRequest request, string baseUrl, string token);
        Task<ObjectResponse<Guid>> Request(RequestWorkflowRequest request, string baseUrl, string token);
        Task<StatusResponse> Approval(ApprovalWorkflowRequest request, string baseUrl, string token);
        Task<StatusResponse> Delegate(DelegateWorkflowRequest request, string baseUrl, string token);

        Task<ObjectResponse<string>> GetDataStatusProcess(string workflow_code, string code, string baseUrl, string token);
        Task<ListResponse<WorkflowUpdateDataHistoryResponse>> GetUpdateDataHistory(string code, int? start, int? length, string baseUrl, string token);
    }
    public class WorkflowService : IWorkflowService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public WorkflowService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<WorkflowDetailResponse>> Detail(WorkflowDetailRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<WorkflowDetailResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/Workflow/detail", request));
        }
        public async Task<ListResponse<WorkflowTaskResponse>> Task(string workflow_code, int? start, int? length, string baseUrl, string token)
        {
            string param = string.Empty;
            if (!string.IsNullOrWhiteSpace(workflow_code))
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}workflow_code={start.Value}";

            if (start.HasValue)
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}start={start.Value}";

            if (length.HasValue)
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}length={length.Value}";

            param = $"{baseUrl}/v1/Workflow/task/{(string.IsNullOrEmpty(param) ? string.Empty : $"?{param}")}";
            return _request.Response(await _request.DoRequest<ListResponse<WorkflowTaskResponse>>(HttpMethod.Get, token, param, null));
        }
        public async Task<ListResponse<WorkflowHistoryResponse>> History(string workflow_code, int? start, int? length, string baseUrl, string token)
        {
            string param = string.Empty;
            if (!string.IsNullOrWhiteSpace(workflow_code))
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}workflow_code={start.Value}";

            if (start.HasValue)
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}start={start.Value}";

            if (length.HasValue)
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}length={length.Value}";

            param = $"{baseUrl}/v1/Workflow/history/{(string.IsNullOrEmpty(param) ? string.Empty : $"?{param}")}";
            return _request.Response(await _request.DoRequest<ListResponse<WorkflowHistoryResponse>>(HttpMethod.Get, token, param, null));
        }

        public async Task<ListResponse<WorkflowResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<WorkflowResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/Workflow/list", request));
        }

        public async Task<ListResponse<WorkflowHistoryResponse>> HistoryOther(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<WorkflowHistoryResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/Workflow/history_other", request));
        }

        public async Task<ObjectResponse<Guid>> Request(RequestWorkflowRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<Guid>>(HttpMethod.Post, token, $"{baseUrl}/v1/Workflow/request", request));
        }
        
        public async Task<StatusResponse> Approval(ApprovalWorkflowRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/Workflow/approval", request));
        }
        
        public async Task<StatusResponse> Delegate(DelegateWorkflowRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/Workflow/delegate", request));
        }
        
        public async Task<ObjectResponse<string>> GetDataStatusProcess(string workflow_code, string code, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<string>>(HttpMethod.Get, token, $"{baseUrl}/v1/Workflow/get_data_status_process/{workflow_code}/{code}", null));
        }

        public async Task<ListResponse<WorkflowUpdateDataHistoryResponse>> GetUpdateDataHistory(string code, int? start, int? length, string baseUrl, string token)
        {
            string param = string.Empty;
            if (!string.IsNullOrWhiteSpace(code))
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}code={code}";

            if (start.HasValue)
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}start={start.Value}";

            if (length.HasValue)
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}length={length.Value}";

            param = $"{baseUrl}/v1/Workflow/get_history_update_data/{(string.IsNullOrEmpty(param) ? string.Empty : $"?{param}")}";
            return _request.Response(await _request.DoRequest<ListResponse<WorkflowUpdateDataHistoryResponse>>(HttpMethod.Get, token, param, null));
        }
    }
}

