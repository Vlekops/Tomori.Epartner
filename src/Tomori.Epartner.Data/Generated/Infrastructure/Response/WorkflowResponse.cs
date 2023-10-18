using System;
using System.Linq;
using System.Text;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class WorkflowResponse
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
		public int StatusCode { get; set; }
		public string StatusDescription { get; set; }
		public int StepNo { get; set; }
		public string Subject { get; set; }
		public string UpdateBy { get; set; }
		public DateTime? UpdateDate { get; set; }
		public string WorkflowCode { get; set; }

    }
}

