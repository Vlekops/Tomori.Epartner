using System;
using System.Linq;
using System.Text;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class ChangeLogPropertyResponse
    {
		public Guid Id { get; set; }
		public Guid IdChangeLog { get; set; }
		public string NewValue { get; set; }
		public string OldValue { get; set; }
		public string Property { get; set; }

    }
}

