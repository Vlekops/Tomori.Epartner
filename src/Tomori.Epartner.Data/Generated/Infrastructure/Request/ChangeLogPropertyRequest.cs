using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class ChangeLogPropertyRequest
    {
		[Required]
		public Guid IdChangeLog { get; set; }
		[Required]
		public string NewValue { get; set; }
		public string OldValue { get; set; }
		[Required]
		public string Property { get; set; }

    }
}

