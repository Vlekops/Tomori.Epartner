using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class ReportRequest
    {
		[Required]
		public bool Active { get; set; }
		public string Description { get; set; }
		[Required]
		public string Modul { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Query { get; set; }

    }
}

