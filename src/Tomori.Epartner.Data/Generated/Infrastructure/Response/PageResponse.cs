using System;
using System.Linq;
using System.Text;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class PageResponse
    {
		public Guid Id { get; set; }
		public bool Active { get; set; }
		public string Code { get; set; }
		public string CreateBy { get; set; }
		public DateTime CreateDate { get; set; }
		public string Description { get; set; }
		public string Icon { get; set; }
		public Guid? IdParent { get; set; }
		public string Name { get; set; }
		public string Navigation { get; set; }
		public string Section { get; set; }
		public int Sort { get; set; }
		public string UpdateBy { get; set; }
		public DateTime? UpdateDate { get; set; }

    }
}

