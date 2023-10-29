using System;
using System.Linq;
using System.Text;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class UserActivityResponse
    {
		public Guid Id { get; set; }
		public DateTime CreateDate { get; set; }
		public Guid IdUser { get; set; }
		public string PageName { get; set; }

    }
}

