using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class ApiLogRequest
    {
		[Required]
		public string Endpoint { get; set; }
		[Required]
		public Guid IdUser { get; set; }
		[Required]
		public string Request { get; set; }
		[Required]
		public string Response { get; set; }

    }
}

