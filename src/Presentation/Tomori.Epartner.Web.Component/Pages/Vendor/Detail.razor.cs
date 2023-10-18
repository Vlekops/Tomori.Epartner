namespace Tomori.Epartner.Web.Component.Pages.Vendor
{
    public partial class Detail : ComponentBase
    {
        [Parameter]
        public Guid IdVendor { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        [Parameter]
        public List<string> Permission { get; set; }
    }
}
