using System;
using System.Linq;
using System.Text;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class RepositoryResponse
    {
		public Guid Id { get; set; }
		public string Base64 { get; set; }
		public string Code { get; set; }
		public string CreateBy { get; set; }
		public DateTime CreateDate { get; set; }
		public string Description { get; set; }
		public string Extension { get; set; }
		public string FileName { get; set; }
		public string MimeType { get; set; }
		public string Modul { get; set; }

    }
}

