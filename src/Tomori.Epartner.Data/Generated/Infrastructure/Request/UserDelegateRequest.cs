using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class UserDelegateRequest
    {
		[Required]
		public DateTime ExpiredDate { get; set; }
		[Required]
		public Guid IdUser { get; set; }
		[Required]
		public Guid IdUserDelegate { get; set; }
		[Required]
		public DateTime StartDate { get; set; }

    }
}

