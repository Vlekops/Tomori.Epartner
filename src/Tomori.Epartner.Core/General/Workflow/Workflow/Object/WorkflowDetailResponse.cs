using Tomori.Epartner.Core.Attributes;

namespace Tomori.Epartner.Core.Response
{
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
}

