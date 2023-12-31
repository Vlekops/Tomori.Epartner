//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
// </auto-generated>
//------------------------------------------------------------------------------

using Tomori.Epartner.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Core.Request
{
    public partial class RequestWorkflowRequest
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string WorkflowCode { get; set; }
        [Required]
        public string Subject { get; set; }
        public string DocumentNo { get; set; }
        public string Description { get; set; }
        public string Data { get; set; }
        public List<FileObject> Attachment { get; set; }
    }
    public partial class ApprovalWorkflowRequest
    {
        [Required]
        public Guid IdWorkflow { get; set; }
        [Required]
        public bool IsApprove { get; set; }
        public string Notes { get; set; }
    }
    public partial class DelegateWorkflowRequest
    {
        [Required]
        public Guid IdWorkflow { get; set; }
        [Required]
        public Guid IdUser { get; set; }
        [Required]
        public DelegateTipeEnum Tipe { get; set; }
        public string Message { get; set; }
    }
    public enum DelegateTipeEnum
    {
        Reviewer,
        Delegate,
        Adhoc
    }
}

