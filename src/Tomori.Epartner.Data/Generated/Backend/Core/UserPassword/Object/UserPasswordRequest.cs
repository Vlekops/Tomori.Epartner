//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Core.Request
{
    public partial class UserPasswordRequest
    {
		[Required]
		public Guid IdUser{ get; set; }
		[Required]
		public string Password{ get; set; }

    }
}

