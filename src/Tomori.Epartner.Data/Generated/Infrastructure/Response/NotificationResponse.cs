using System;
using System.Linq;
using System.Text;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class NotificationResponse
    {
		public Guid Id { get; set; }
		public string CreateBy { get; set; }
		public DateTime CreateDate { get; set; }
		public string Description { get; set; }
		public Guid IdUser { get; set; }
		public bool IsOpen { get; set; }
		public string Navigation { get; set; }
		public string Subject { get; set; }

    }
}

