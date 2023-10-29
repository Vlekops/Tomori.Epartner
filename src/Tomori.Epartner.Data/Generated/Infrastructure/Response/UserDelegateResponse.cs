using System;
using System.Linq;
using System.Text;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class UserDelegateResponse
    {
		public Guid Id { get; set; }
		public string CreateBy { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime ExpiredDate { get; set; }
		public Guid IdUser { get; set; }
		public Guid IdUserDelegate { get; set; }
		public DateTime StartDate { get; set; }

    }
}

