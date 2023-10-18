using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class ChangeLogRequest
    {
		[Required]
		public Guid IdUser { get; set; }
		[Required]
		public string PrimaryKey { get; set; }
		[Required]
		public string TableName { get; set; }
		[Required]
		public string Tipe { get; set; }

    }
}

