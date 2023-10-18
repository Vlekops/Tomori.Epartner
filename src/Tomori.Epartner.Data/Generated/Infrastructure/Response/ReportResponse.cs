using System;
using System.Linq;
using System.Text;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class ReportResponse
    {
		public Guid Id { get; set; }
		public bool Active { get; set; }
		public string CreateBy { get; set; }
		public DateTime CreateDate { get; set; }
		public string Description { get; set; }
		public string Modul { get; set; }
		public string Name { get; set; }
		public string Query { get; set; }
		public string UpdateBy { get; set; }
		public DateTime? UpdateDate { get; set; }

    }
}

