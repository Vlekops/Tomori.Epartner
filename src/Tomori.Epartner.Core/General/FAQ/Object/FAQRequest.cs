//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Core.Request
{
    public partial class FAQRequest
    {
		[Required]
		public string Answer{ get; set; }
		[Required]
		public string Questionnaire{ get; set; }
		[Required]
		public string Section{ get; set; }

    }
}

