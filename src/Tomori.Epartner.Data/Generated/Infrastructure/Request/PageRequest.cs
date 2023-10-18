using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class PageRequest
    {
		[Required]
		public bool Active { get; set; }
		[Required]
		public string Code { get; set; }
		public string Description { get; set; }
		public string Icon { get; set; }
		public Guid? IdParent { get; set; }
		[Required]
		public string Name { get; set; }
		public string Navigation { get; set; }
		public string Section { get; set; }
		[Required]
		public int Sort { get; set; }

    }
}

