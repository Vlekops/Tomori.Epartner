using System;
using System.Linq;
using System.Text;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class RolePermissionResponse
    {
		public Guid Id { get; set; }
		public string CreateBy { get; set; }
		public DateTime CreateDate { get; set; }
		public Guid IdPermission { get; set; }
		public string IdRole { get; set; }

    }
}

