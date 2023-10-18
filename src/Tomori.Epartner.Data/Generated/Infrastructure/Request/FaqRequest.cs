using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class FaqRequest
    {
		[Required]
		public bool Active { get; set; }
		[Required]
		public string Answer { get; set; }
		[Required]
		public string Questionnaire { get; set; }
		[Required]
		public string Section { get; set; }

    }
}

