using System;
using System.Linq;
using System.Text;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class ConfigResponse
    {
		public string Id { get; set; }
		public string Category { get; set; }
		public string CreateBy { get; set; }
		public DateTime CreateDate { get; set; }
		public string Name { get; set; }
		public string UpdateBy { get; set; }
		public DateTime? UpdateDate { get; set; }
		public string Value { get; set; }

    }
}

