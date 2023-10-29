using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class CounterTransactionRequest
    {
		[Required]
		public int Counter { get; set; }
		[Required]
		public string Modul { get; set; }
		[Required]
		public int Month { get; set; }
		[Required]
		public int Year { get; set; }

    }
}

