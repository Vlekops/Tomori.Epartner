using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomori.Epartner.Core.Response
{
    public partial class WorkflowCallbackRequest
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string WorkflowCode { get; set; }
        [Required]
        public bool IsApprove { get; set; }
        public string Data { get; set; }
        public Guid IdUserApprover { get; set; }
        public string FullnameApprover { get; set; }
        public string EmailApprover { get; set; }
    }
}
