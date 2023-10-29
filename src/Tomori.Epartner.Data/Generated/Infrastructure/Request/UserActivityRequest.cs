using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class UserActivityRequest
    {
		[Required]
		public Guid IdUser { get; set; }
		[Required]
		public string PageName { get; set; }

    }
}

