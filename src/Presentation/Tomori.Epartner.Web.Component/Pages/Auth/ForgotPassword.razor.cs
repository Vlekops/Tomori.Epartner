namespace Tomori.Epartner.Web.Component.Pages.Auth
{
    public partial class ForgotPassword:ComponentBase
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
        private IRequestHelper _Req { get; set; }
        [Inject]
        private IDialogService _DialogService { get; set; }
        [Inject]
        private NavigationManager _NavManager { get; set; }
        #endregion

        #region Field
        private MudForm _ForgotPasswordForm;
        private bool _ForgotPasswordFormIsValid;
        private bool _ForgotPAsswordFormIsLoading = false;
        private string _Message = string.Empty;

        private string _Email = string.Empty;
        #endregion

        #region Method
        private async Task SendForgotPassword()
        {
            
            
            StateHasChanged();
            try
            {
                var baseUri = _NavManager.BaseUri;
                var res = _Req.Response(await _Req.DoRequest<StatusResponse>(HttpMethod.Post, null, $"{baseUri}Account/ForgotPassword?email="+ _Email, null));
                if (res.Succeeded)
                {
                    _Message = "Check Your Email!";
                }
                else
                    _Message = res.GetErrorMessage();
            }
            catch (Exception ex)
            {
                _Message = ex.ToString();
            }

            StateHasChanged();
        }

        #endregion


    }
}
