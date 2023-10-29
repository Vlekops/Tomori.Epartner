using Blazored.LocalStorage;
using System.Reflection.Metadata;

namespace Tomori.Epartner.Web.Component.Shared
{
    public partial class UtilityComponent : ComponentBase
    {
        #region Override
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await _JS.DotNetInit(DotNetObjectReference.Create(this));
                await _HubService.Connect();
                await _HubService.ForceLogoff(ForceLogoff);
                await CheckUser();
            }

            await base.OnAfterRenderAsync(firstRender);
        }
        #endregion

        #region Inject, Cascading, Parameter
        [Inject]
        private IHubService _HubService { get; set; }
        [Inject]
        private ILocalStorageService _LocalStorage { get; set; }
        [Inject]
        private IUserService _UserService { get; set; }
        [Inject]
        private IJSRuntime _JS { get; set; }
        [Inject]
        public ISnackbar _Snackbar { get; set; }
        [Inject]
        private IRequestHelper _Req { get; set; }
        [Inject]
        public IDialogService _DialogService { get; set; }
        [Inject]
        private NavigationManager _NavManager { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        #endregion

        #region Field
        private bool _MainIsLoading = false;
        #endregion

        #region Method
        [JSInvokable]
        public void SetBodyLoading(bool value)
        {
            _MainIsLoading = value;
            StateHasChanged();
        }

        #region Logoff
        [JSInvokable]
        public async Task DoLogoff(string message)
        {
            await Logoff("Idle Login", message);
        }
        private async Task Logoff(string key, string message)
        {
            try
            {
                var baseUri = _NavManager.BaseUri;
                var res = _Req.Response(await _Req.DoRequest<StatusResponse>(HttpMethod.Post, null, $"{baseUri}Account/LogOffRequest", null));
                if (res.Succeeded)
                {
                    await _HubService.Logoff(Token.User.Id);
                    _ = await _DialogService.ShowMessageBox(key, message, yesText: "OK", noText: null, options: new DialogOptions { MaxWidth = MaxWidth.ExtraSmall });
                    await _LocalStorage.ClearAsync();
                    _NavManager.NavigateTo("/Account/Login", true);
                }
                else
                    _Snackbar.ShowError(res.GetErrorMessage());
            }
            catch (Exception ex)
            {
                _Snackbar.ShowError(ex.Message);
            }
        }
        private async void ForceLogoff(string message)
        {
            await Logoff("Force Logoff", message);
        }
        #endregion

        private async Task CheckUser()
        {
            CheckUserResponse check = await _LocalStorage.GetItemAsync<CheckUserResponse>("Tomori.Epartner");
            if (check != null && check.Code == 0)
                return;

            var check_user = await _UserService.CheckUser(Token.BaseApiUrl, Token.RawToken);
            if (!check_user.Succeeded)
            {
                _Snackbar.ShowError(check_user.GetErrorMessage());
                return;
            }
            await _LocalStorage.RemoveItemAsync("Tomori.Epartner");
            await _LocalStorage.SetItemAsync("Tomori.Epartner", check_user.Data);
            if (check_user.Data.Code == 0)
            {
                string message = "Selamat Datang di applikasi EPartner silahkan melakukan pekerjaan anda!";
                _ = await _DialogService.ShowMessageBox("Success Login", message, yesText: "OK", noText: null, options: new DialogOptions { MaxWidth = MaxWidth.ExtraSmall });
                await _LocalStorage.SetItemAsync("Tomori.Epartner", check_user.Data);
            }
            else
            {
                _ = await _DialogService.ShowMessageBox("Reset Password", check_user.Data.Message, yesText: "OK", noText: null, options: new DialogOptions { MaxWidth = MaxWidth.ExtraSmall });
                var paramDialog = new DialogParameters
                {
                    { "Token", Token }
                };

                var dialog = _DialogService.Show<ChangePassword>("Change Password", paramDialog, new DialogOptions { MaxWidth = MaxWidth.Small });
                var dialogResult = await dialog.Result;
                if (!dialogResult.Canceled)
                {
                    _Snackbar.ShowSuccess("Change Password Berhasil!");
                    await _LocalStorage.SetItemAsync("Tomori.Epartner", new CheckUserResponse()
                    {
                        Code = 0,
                        Message = "OK"
                    });
                }
            }
        }
        #endregion
    }
}
