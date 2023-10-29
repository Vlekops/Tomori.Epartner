using System;
using System.Linq;
using System.Text;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class WorkflowAttachmentResponse
    {
		public Guid Id { get; set; }
		public string CreateBy { get; set; }
		public DateTime CreateDate { get; set; }
		public Guid IdRepository { get; set; }
		public Guid IdWorkflow { get; set; }

    }
}

