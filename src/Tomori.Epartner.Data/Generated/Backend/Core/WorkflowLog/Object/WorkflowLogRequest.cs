//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Core.Request
{
    public partial class WorkflowLogRequest
    {
		public string Email{ get; set; }
		[Required]
		public string Fullname{ get; set; }
		[Required]
		public int GroupNo{ get; set; }
		[Required]
		public Guid IdUser{ get; set; }
		[Required]
		public Guid IdWorkflow{ get; set; }
		[Required]
		public short IdWorkflowStatus{ get; set; }
		[Required]
		public bool IsAdhoc{ get; set; }
		[Required]
		public bool IsReviewer{ get; set; }
		public string Notes{ get; set; }
		[Required]
		public string StatusDescription{ get; set; }
		[Required]
		public string StepName{ get; set; }
		[Required]
		public int StepNo{ get; set; }

    }
}

