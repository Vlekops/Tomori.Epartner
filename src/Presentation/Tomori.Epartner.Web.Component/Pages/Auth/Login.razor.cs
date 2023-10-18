

namespace Tomori.Epartner.Web.Component.Pages.Auth
{
    public partial class Login : ComponentBase
    {
        #region Override
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await _HubService.Connect();
            }

            await base.OnAfterRenderAsync(firstRender);
        }
        #endregion

        #region Inject, Cascading, Parameter
        [Inject]
        private IRequestHelper _Req { get; set; }
        [Inject]
        private IHubService _HubService { get; set; }
        [Inject]
        private IDialogService _DialogService { get; set; }
        [Inject]
        private NavigationManager _NavManager { get; set; }
        #endregion

        #region Field
        private MudForm _LoginForm;
        private bool _LoginFormIsValid;
        private bool _LoginFormIsLoading = false;
        private string _Message = string.Empty;

        private string _Username = string.Empty;
        private string _Password = string.Empty;

        private InputType _PasswordInput = InputType.Password;
        private bool _PasswordIsShow = false;
        private string _PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
        #endregion

        #region Method
        private async Task DoLogin()
        {
            _Message = string.Empty;

            if (_LoginForm != null)
                await _LoginForm.Validate();

            if (!_LoginFormIsValid)
                return;

            if (await _HubService.ConnectedUser(_Username))
            {
                var confirm = await _DialogService.ShowMessageBox("Konfirmasi", "User ini sedang digunakan di device lain! apakah anda akan melakukan logout didevice lain?", yesText: "Force Logoff", noText: "No", options: new DialogOptions { MaxWidth = MaxWidth.ExtraSmall });
                if (confirm == null || !confirm.Value)
                    return;
                else
                    await _HubService.SendLogoff(_Username, "Device anda dipaksa untuk melakukan logout dikarenakan ada device lain yang ingin login!");
            }
            _LoginFormIsLoading = true;
            StateHasChanged();
            try
            {
                var baseUri = _NavManager.BaseUri;
                var res = _Req.Response(await _Req.DoRequest<StatusResponse>(HttpMethod.Post, null, $"{baseUri}Account/Login", new
                {
                    Username = _Username,
                    Password = _Password
                }));

                if (res.Succeeded)
                {
                    string redirect = StaticMethod.GetQueryParm(_NavManager, "redirect");
                    if (!string.IsNullOrWhiteSpace(redirect))
                        _NavManager.NavigateTo(redirect, true);
                    else
                        _NavManager.NavigateTo("/", true);
                }
                else
                {
                    _LoginFormIsLoading = false;
                    _Message = res.GetErrorMessage();
                    StateHasChanged();
                }
            }
            catch (Exception ex)
            {
                _Message = ex.ToString();
                _LoginFormIsLoading = false;
                StateHasChanged();
            }
        }

        private void ShowHidePassword()
        {
            _PasswordInputIcon = _PasswordIsShow ? Icons.Material.Filled.VisibilityOff : Icons.Material.Filled.Visibility;
            _PasswordInput = _PasswordIsShow ? InputType.Password : InputType.Text;
            _PasswordIsShow = !_PasswordIsShow;
        }

        private async Task OnKeyPress(KeyboardEventArgs args)
        {
            if (args != null && args.Key != null && args.Key.Equals("Enter"))
            {
                await DoLogin();
            }
        }
        #endregion

    }
}
