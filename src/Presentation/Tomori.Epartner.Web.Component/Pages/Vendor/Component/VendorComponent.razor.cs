using MudBlazor;

namespace Tomori.Epartner.Web.Component.Pages.Vendor.Component
{
    public partial class VendorComponent : ComponentBase
    {
        #region Override
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _ = GetData();
            }
            await base.OnAfterRenderAsync(firstRender);
        }
        #endregion

        #region Inject, Cascading, Parameter
        [Inject]
        private ISnackbar _Snackbar { get; set; }
        [Inject]
        private IDialogService _DialogService { get; set; }
        [Inject]
        private IVendorService _Service { get; set; }
        [Parameter]
        public Guid VendorId { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        #endregion

        #region Field
        private MudForm _Form;
        private bool _FormIsValid;
        private bool _FormIsLoading;
        private VendorResponse _Data;
        #endregion

        #region Method
        private async Task GetData()
        {
            _FormIsLoading = true;
            StateHasChanged();

            try
            {
                var res = await _Service.Get(VendorId, Token.BaseApiUrl, Token.RawToken);
                if (res.Succeeded)
                {
                    _Data = res.Data;
                }
                else
                    _Snackbar.ShowError($"Error While Request :: {res.GetErrorMessage()}");
            }
            catch (Exception ex)
            {
                _Snackbar.ShowError($"Error at GetDataTable :: {ex.Message}");
            }

            _FormIsLoading = false;
            StateHasChanged();
        }
        #endregion
    }
}
