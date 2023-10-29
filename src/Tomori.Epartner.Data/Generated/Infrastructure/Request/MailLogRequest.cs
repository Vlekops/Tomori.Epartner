using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class MailLogRequest
    {
		[Required]
		public string BodyMail { get; set; }
		public string CcMail { get; set; }
		[Required]
		public Guid IdUser { get; set; }
		[Required]
		public string SenderMail { get; set; }
		[Required]
		public string Subject { get; set; }
		[Required]
		public string ToMail { get; set; }

    }
}

