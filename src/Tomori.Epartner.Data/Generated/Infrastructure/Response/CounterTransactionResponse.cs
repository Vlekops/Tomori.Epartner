using System;
using System.Linq;
using System.Text;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class CounterTransactionResponse
    {
		public Guid Id { get; set; }
		public int Counter { get; set; }
		public string CreateBy { get; set; }
		public DateTime CreateDate { get; set; }
		public string Modul { get; set; }
		public int Month { get; set; }
		public int Year { get; set; }

    }
}

