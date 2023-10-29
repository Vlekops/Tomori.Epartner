using System.Security.Cryptography;

namespace Tomori.Epartner.Web.Component.Pages.FiturUmum.Dialog
{
    public partial class DialogDelegasi : ComponentBase
    {
        #region Override
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (DataEdit != null)
                {
                    _ = GetUser(DataEdit.UserDelegasi.Id, true);
                    _ = GetUser(DataEdit.User.Id, false);
                    _StartDate = DataEdit.StartDate;
                    _ExpiredDate = DataEdit.ExpiredDate;
                    StateHasChanged();
                }
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
        private IUserDelegateService _Service { get; set; }
        [Inject]
        private IUserService _UserService { get; set; }
        [CascadingParameter]
        private MudDialogInstance _MudDialog { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        [Parameter]
        public UserDelegateResponse DataEdit { get; set; }
        #endregion

        #region Field
        private MudForm _Form;
        private bool _FormIsValid;
        private bool _FormIsLoading;


        private MudAutocomplete<UserResponse> _UserElement;
        private UserResponse _UserSelected = null;
        private bool _UserIsLoading = false;

        private MudAutocomplete<UserResponse> _UserDelegateElement;
        private UserResponse _UserDelegateSelected = null;
        private bool _UserDelegateIsLoading = false;

        private DateTime _StartDate;
        private DateTime _ExpiredDate;
        #endregion

        #region Method
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
                var param = new UserDelegateRequest
                {
                    IdUser = _UserSelected.Id,
                    IdUserDelegate = _UserDelegateSelected.Id,
                    ExpiredDate = _ExpiredDate,
                    StartDate = _StartDate
                };

                StatusResponse res = null;
                if (DataEdit == null)
                    res = await _Service.Add(param, Token.BaseApiUrl, Token.RawToken);
                else
                    res = await _Service.Edit(DataEdit.Id, param, Token.BaseApiUrl, Token.RawToken);

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

        #region User
        private async Task<IEnumerable<UserResponse>> SearchUser(string value)
        {
            var result = new List<UserResponse>();
            try
            {
                var param = new ListRequest
                {
                    Start = 1,
                    Length = 11,
                    Filter = new List<FilterRequest>(),
                    Sort = new SortRequest("id", SortTypeEnum.ASC)
                };

                if (!string.IsNullOrEmpty(value))
                    param.Filter.Add(new FilterRequest("id_name_description", value));

                var res = await _UserService.List(param, Token.BaseApiUrl, Token.RawToken);

                if (res.Succeeded)
                    result = res.List;
                else
                    _Snackbar.ShowError(res.GetErrorMessage());
            }
            catch (Exception ex)
            {
                _Snackbar.ShowError(ex.Message);
            }
            return result;
        }

        private async Task GetUser(Guid value, bool is_delegasi)
        {
            if (is_delegasi)
                _UserDelegateIsLoading = true;
            else
                _UserIsLoading = true;
            StateHasChanged();
            try
            {
                var result = await _UserService.Get(value, Token.BaseApiUrl, Token.RawToken);
                if (!result.Succeeded)
                {
                    _Snackbar.ShowError(result.Message);
                    return;
                }
                if (is_delegasi)
                    _UserDelegateSelected = result.Data;
                else
                    _UserSelected = result.Data;

                if (is_delegasi)
                    _UserDelegateIsLoading = false;
                else
                    _UserIsLoading = false;

                StateHasChanged();

                if (is_delegasi)
                {
                    if (_UserDelegateElement.Error)
                        _UserDelegateElement.ResetValidation();
                }
                else
                {
                    if (_UserElement.Error)
                        _UserElement.ResetValidation();
                }
            }
            catch (Exception ex)
            {
                _Snackbar.ShowError(ex.Message);
            }
        }
        #endregion

    }
}
