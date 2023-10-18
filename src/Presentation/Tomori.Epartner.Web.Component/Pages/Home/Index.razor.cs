namespace Tomori.Epartner.Web.Component.Pages.Home
{
    public partial class Index : ComponentBase
    {
        [Parameter]
        public TokenModel Token { get; set; }
        [Parameter]
        public List<string> Permission { get; set; }
    }
}
