using Tomori.Epartner.Web.Component.Pages.FiturUmum.Dialog;
using Tomori.Epartner.Web.Component.Pages.Report.Dialog;

namespace Tomori.Epartner.Web.Component.Pages.FiturUmum
{
    public partial class Config : ComponentBase
    {
        [Parameter]
        public TokenModel Token { get; set; }
        [Parameter]
        public List<string> Permission { get; set; }
    }
}
