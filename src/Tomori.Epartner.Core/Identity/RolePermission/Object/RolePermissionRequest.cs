//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Core.Request
{
    public partial class RolePermissionRequest
    {
		[Required]
		public Guid IdPermission{ get; set; }
		[Required]
		public string IdRole{ get; set; }

    }
}
