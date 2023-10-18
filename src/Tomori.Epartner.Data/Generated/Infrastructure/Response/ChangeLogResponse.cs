using System;
using System.Linq;
using System.Text;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class ChangeLogResponse
    {
		public Guid Id { get; set; }
		public DateTime CreateDate { get; set; }
		public Guid IdUser { get; set; }
		public string PrimaryKey { get; set; }
		public string TableName { get; set; }
		public string Tipe { get; set; }

    }
}

