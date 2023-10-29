using System;
using System.Linq;
using System.Text;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class FaqResponse
    {
		public Guid Id { get; set; }
		public bool Active { get; set; }
		public string Answer { get; set; }
		public string CreateBy { get; set; }
		public DateTime CreateDate { get; set; }
		public string Questionnaire { get; set; }
		public string Section { get; set; }
		public string UpdateBy { get; set; }
		public DateTime? UpdateDate { get; set; }

    }
}

