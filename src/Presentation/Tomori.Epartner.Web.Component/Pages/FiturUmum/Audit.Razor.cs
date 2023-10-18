using Microsoft.AspNetCore.Components;

namespace Tomori.Epartner.Web.Component.Pages.FiturUmum
{
    public partial class Audit : ComponentBase
    {
        #region Override
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {

            }

            await base.OnAfterRenderAsync(firstRender);
        }
        #endregion

        #region Inject, Cascading, Parameter
        [Inject]
        private ISnackbar _Snackbar { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        #endregion
    }
}
