using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Core.Attributes;

namespace Tomori.Epartner.Core.Response
{
    public partial class SyncResponse<T>
    {
        public string correlationId { get; set; }
        public int status { get; set; }
        public bool success { get; set; }
        public string error { get; set; }
        public List<T> result {get; set;}
    }
}

