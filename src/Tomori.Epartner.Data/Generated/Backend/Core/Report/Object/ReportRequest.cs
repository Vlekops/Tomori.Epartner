//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Core.Request
{
    public partial class ReportRequest
    {
		[Required]
		public bool Active{ get; set; }
		public string Description{ get; set; }
		[Required]
		public string Modul{ get; set; }
		[Required]
		public string Name{ get; set; }
		[Required]
		public string Query{ get; set; }

    }
}

