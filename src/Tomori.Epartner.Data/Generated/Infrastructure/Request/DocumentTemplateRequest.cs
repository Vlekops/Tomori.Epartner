using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class DocumentTemplateRequest
    {
		[Required]
		public bool Active { get; set; }
		[Required]
		public string Code { get; set; }
		[Required]
		public string Subject { get; set; }
		[Required]
		public string Value { get; set; }

    }
}

