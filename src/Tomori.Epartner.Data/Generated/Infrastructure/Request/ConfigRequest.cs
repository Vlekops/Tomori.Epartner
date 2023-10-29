using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class ConfigRequest
    {
		[Required]
		public string Id { get; set; }
		[Required]
		public string Category { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Value { get; set; }

    }
}

