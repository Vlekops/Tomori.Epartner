using Vleko.Result;
using System.ComponentModel.DataAnnotations;
using Tomori.Epartner.Core.Attributes;

namespace Tomori.Epartner.Core.Request
{
    public partial class RepositoryRequest
    {
        [Required]
        public string Modul { get; set; }
        [Required]
        public FileObject File { get; set; }
        [Required]
		public string Code{ get; set; }
		public string Description{ get; set; }

    }
}

