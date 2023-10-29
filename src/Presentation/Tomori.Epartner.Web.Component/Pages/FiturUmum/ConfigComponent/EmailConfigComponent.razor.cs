using MudBlazor;

namespace Tomori.Epartner.Web.Component.Pages.FiturUmum.ConfigComponent
{
    public partial class EmailConfigComponent : ComponentBase
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

        private string _Smtp = string.Empty;
        private int _SmtpPort = 0;
        private string _SenderMail = string.Empty;
        private string _Password = string.Empty;
        #endregion

        #region Method
        private async Task GetData()
        {
            _FormIsLoading = true;
            StateHasChanged();

            try
            {
                var res = await _Service.GetEmail(Token.BaseApiUrl, Token.RawToken);
                if (res.Succeeded)
                {
                    _Smtp = res.Data.Smtp;
                    _SmtpPort = res.Data.SmtpPort;
                    _SenderMail = res.Data.SenderMail;
                    _Password = res.Data.Password;
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
                var param = new EmailConfig
                {
                    Password = _Password,
                    SenderMail = _SenderMail,
                    SmtpPort = _SmtpPort,
                    Smtp = _Smtp
                };

                StatusResponse res = await _Service.SaveMail(param, Token.BaseApiUrl, Token.RawToken);

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
