//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Core.Request
{
    public partial class PagePermissionRequest
    {
		[Required]
		public bool Active{ get; set; }
		[Required]
		public Guid IdPage{ get; set; }
		[Required]
		public string Name{ get; set; }

    }
}
