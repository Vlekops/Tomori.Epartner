//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Core.Request
{
    public partial class ReportRoleRequest
    {
		[Required]
		public Guid IdReport{ get; set; }
		[Required]
		public string IdRole{ get; set; }

    }
}

