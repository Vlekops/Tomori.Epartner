using System;
using System.Linq;
using System.Text;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class MailLogResponse
    {
		public Guid Id { get; set; }
		public string BodyMail { get; set; }
		public string CcMail { get; set; }
		public DateTime CreateDate { get; set; }
		public Guid IdUser { get; set; }
		public string SenderMail { get; set; }
		public string Subject { get; set; }
		public string ToMail { get; set; }

    }
}

