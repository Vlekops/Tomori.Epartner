//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Core.Request
{
    public partial class RepositoryRequest
    {
		[Required]
		public string Base64{ get; set; }
		[Required]
		public string Code{ get; set; }
		public string Description{ get; set; }
		[Required]
		public string Extension{ get; set; }
		[Required]
		public string FileName{ get; set; }
		[Required]
		public string MimeType{ get; set; }
		[Required]
		public string Modul{ get; set; }

    }
}

