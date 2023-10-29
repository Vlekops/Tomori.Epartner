
namespace Tomori.Epartner.Web.Component.Shared
{
    public partial class ChangePassword : ComponentBase
    {
        #region Override
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
        }
        #endregion

        #region Inject, Cascading, Parameter
        [Inject]
        private ISnackbar _Snackbar { get; set; }
        [Inject]
        private IDialogService _DialogService { get; set; }
        [Inject]
        private IUserService _UserService { get; set; }
        [CascadingParameter]
        private MudDialogInstance _MudDialog { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        #endregion

        #region Field
        private MudForm _Form;
        private bool _FormIsValid;
        private bool _FormIsLoading;

        private string _Password = string.Empty;

        private InputType _PasswordInput = InputType.Password;
        private bool _PasswordIsShow = false;
        private string _PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
        #endregion

        #region Method
        private void ShowHidePassword()
        {
            _PasswordInputIcon = _PasswordIsShow ? Icons.Material.Filled.VisibilityOff : Icons.Material.Filled.Visibility;
            _PasswordInput = _PasswordIsShow ? InputType.Password : InputType.Text;
            _PasswordIsShow = !_PasswordIsShow;
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
                var res = await _UserService.ChangePassword(Token.User.Id, _Password, Token.BaseApiUrl,Token.RawToken);
                if (res != null && res.Succeeded)
                    _MudDialog.Close(DialogResult.Ok(true));
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
