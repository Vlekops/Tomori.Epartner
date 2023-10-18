using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class RepositoryRequest
    {
		[Required]
		public string Base64 { get; set; }
		[Required]
		public string Code { get; set; }
		public string Description { get; set; }
		[Required]
		public string Extension { get; set; }
		[Required]
		public string FileName { get; set; }
		[Required]
		public string MimeType { get; set; }
		[Required]
		public string Modul { get; set; }

    }
}

