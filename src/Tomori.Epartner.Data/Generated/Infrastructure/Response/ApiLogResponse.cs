using System;
using System.Linq;
using System.Text;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class ApiLogResponse
    {
		public Guid Id { get; set; }
		public DateTime CreateDate { get; set; }
		public string Endpoint { get; set; }
		public Guid IdUser { get; set; }
		public string Request { get; set; }
		public string Response { get; set; }

    }
}

