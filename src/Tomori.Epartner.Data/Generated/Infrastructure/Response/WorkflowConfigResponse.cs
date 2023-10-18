using System;
using System.Linq;
using System.Text;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class WorkflowConfigResponse
    {
		public Guid Id { get; set; }
		public bool Active { get; set; }
		public string CallbackUrl { get; set; }
		public string Code { get; set; }
		public string CreateBy { get; set; }
		public DateTime CreateDate { get; set; }
		public bool IsSequence { get; set; }
		public string Name { get; set; }
		public string NavigationUrl { get; set; }
		public string UpdateBy { get; set; }
		public DateTime? UpdateDate { get; set; }

    }
}

