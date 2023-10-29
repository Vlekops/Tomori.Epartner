using MudBlazor;

namespace Tomori.Epartner.Web.Component.Pages.FiturUmum.ConfigComponent
{
    public partial class SettingConfigComponent : ComponentBase
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
        private IConfigService _Service { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        #endregion

        #region Field
        private MudForm _Form;
        private bool _FormIsValid;
        private bool _FormIsLoading;

        private string _DefaultPassword = string.Empty;
        private int _IdleTimeMinutes = 0;
        private int _MaxLoginRetry = 0;
        private int _PasswordExpiredDays = 0;
        private int _MinimumPasswordLength = 0;
        private bool _MinOneNumber = false;
        private bool _ResetPasswordAtLogin = false;
        private bool _MinSpecialCharacter = false;
        private bool _MinOneUpperLowerCaseLetter = false;
        private int _MinimumSamePassword = 0;
        private int _ExpireSessionTime = 0;
        private int _UserExpiredDays = 0;
        #endregion

        #region Method
        private async Task GetData()
        {
            _FormIsLoading = true;
            StateHasChanged();

            try
            {
                var res = await _Service.GetSetting(Token.BaseApiUrl, Token.RawToken);
                if (res.Succeeded)
                {
                    _DefaultPassword = res.Data.DefaultPassword;
                    _IdleTimeMinutes = res.Data.IdleTimeMinutes;
                    _MaxLoginRetry = res.Data.MaxLoginRetry;
                    _PasswordExpiredDays = res.Data.PasswordExpiredDays;
                    _MinimumPasswordLength = res.Data.MinimumPasswordLength;
                    _MinOneNumber = res.Data.MinOneNumber;
                    _ResetPasswordAtLogin = res.Data.ResetPasswordAtLogin;
                    _MinSpecialCharacter = res.Data.MinSpecialCharacter;
                    _MinOneUpperLowerCaseLetter = res.Data.MinOneUpperLowerCaseLetter;
                    _MinimumSamePassword = res.Data.MinimumSamePassword;
                    _ExpireSessionTime = res.Data.ExpireSessionTime;
                    _UserExpiredDays = res.Data.UserExpiredDays;
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
        private async Task Save()
        {
            await _Form.Validate();

            if (!_FormIsValid)
            {
                _Snackbar.ShowWarning("Ada Beberapa Field Yang Belum Terisi!");
                return;
            }

            var confirm = await _DialogService.ShowMessageBox("Konfirmasi", "Apakah Anda Yakin?", yesText: "Ya", noText: "Tidak", options: new DialogOptions { MaxWidth = MaxWidth.ExtraSmall });
            if (confirm == null || !confirm.Value)
                return;

            _FormIsLoading = true;
            StateHasChanged();
            try
            {
                var param = new SettingConfig
                {
                    ResetPasswordAtLogin = _ResetPasswordAtLogin,
                    DefaultPassword = _DefaultPassword,
                    ExpireSessionTime = _ExpireSessionTime,
                    IdleTimeMinutes = _IdleTimeMinutes,
                    MaxLoginRetry = _MaxLoginRetry,
                    MinimumPasswordLength = _MinimumPasswordLength,
                    MinimumSamePassword = _MinimumSamePassword,
                    MinOneNumber = _MinOneNumber,
                    MinOneUpperLowerCaseLetter = _MinOneUpperLowerCaseLetter,
                    MinSpecialCharacter = _MinSpecialCharacter,
                    PasswordExpiredDays = _PasswordExpiredDays,
                    UserExpiredDays = _UserExpiredDays
                };

                StatusResponse res = await _Service.SaveSetting(param, Token.BaseApiUrl, Token.RawToken);

                if (res != null && res.Succeeded)
                    _Snackbar.ShowSuccess("Save Data Berhasil!");
                else if (res != null && !res.Succeeded)
                    _Snackbar.ShowError($"Error While Request :: {res.GetErrorMessage()}");
                else if (res == null)
                    _Snackbar.ShowError("Something Went Wrong! Response is Null!");
            }
            catch (Exception ex)
            {
                _Snackbar.ShowError($"Error at Save :: {ex.Message}");
            }

            _FormIsLoading = false;
            StateHasChanged();
        }

        #endregion
    }
}
