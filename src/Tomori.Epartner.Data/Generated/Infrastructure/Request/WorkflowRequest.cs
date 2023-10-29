using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class WorkflowRequest
    {
		public string CallbackUrl { get; set; }
		[Required]
		public string Code { get; set; }
		public string DataWorkflow { get; set; }
		public string Description { get; set; }
		public string DocumentNo { get; set; }
		public string EmailRequester { get; set; }
		[Required]
		public string FullnameRequester { get; set; }
		[Required]
		public int GroupNo { get; set; }
		[Required]
		public Guid IdUserRequester { get; set; }
		public string NavigationUrl { get; set; }
		[Required]
		public int StatusCode { get; set; }
		[Required]
		public string StatusDescription { get; set; }
		[Required]
		public int StepNo { get; set; }
		[Required]
		public string Subject { get; set; }
		[Required]
		public string WorkflowCode { get; set; }

    }
}
