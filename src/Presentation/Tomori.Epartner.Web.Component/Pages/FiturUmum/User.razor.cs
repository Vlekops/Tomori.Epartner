using Tomori.Epartner.Web.Component.Pages.FiturUmum.Dialog;
using Tomori.Epartner.Web.Component.Pages.FiturUmum.Dialog.User;

namespace Tomori.Epartner.Web.Component.Pages.FiturUmum
{
    public partial class User : ComponentBase
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
        private IHubService _HubService { get; set; }
        [Inject]
        private ISnackbar _Snackbar { get; set; }
        [Inject]
        private IDialogService _DialogService { get; set; }
        [Inject]
        private IUserService _UserService { get; set; }
        [Inject]
        private NavigationManager _NavManager { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        [Parameter]
        public List<string> Permission { get; set; }
        #endregion

        #region Field
        private bool _TableIsLoading = false;
        private MudDataGrid<TableRowWrapper<UserResponse>> _Table;

        #endregion

        #region Method
        private async Task<GridData<TableRowWrapper<UserResponse>>> GetDataTable(GridState<TableRowWrapper<UserResponse>> state)
        {
            var result = new GridData<TableRowWrapper<UserResponse>>
            {
                Items = new List<TableRowWrapper<UserResponse>>(),
                TotalItems = 0
            };

            _TableIsLoading = true;
            StateHasChanged();

            try
            {
                var param = new ListRequest
                {
                    Start = state.Page + 1,
                    Length = state.PageSize,
                    Filter = new List<FilterRequest>(),
                    Sort = new SortRequest("createdate", SortTypeEnum.DESC)
                };

                if (state.SortDefinitions.Any())
                {
                    var obj = state.SortDefinitions.FirstOrDefault();
                    param.Sort = new SortRequest(obj.SortBy, obj.Descending ? SortTypeEnum.DESC : SortTypeEnum.ASC);
                }

                foreach (var item in state.FilterDefinitions)
                {
                    param.Filter.Add(new FilterRequest(item.Column.PropertyName, item.Value?.ToString() ?? ""));
                }

                var res = await _UserService.List(param, Token.BaseApiUrl, Token.RawToken);

                if (res.Succeeded)
                {
                    result.Items = res.List.GenerateRowNumber(StaticMethod.GetStartRowNumber(param.Start.Value, param.Length.Value)).ToList();
                    result.TotalItems = res.Count ?? 0;
                }
                else
                    _Snackbar.ShowError($"Error While Request :: {res.GetErrorMessage()}");
            }
            catch (Exception ex)
            {
                _Snackbar.ShowError($"Error at GetDataTable :: {ex.Message}");
            }

            _TableIsLoading = false;
            StateHasChanged();

            return result;
        }

        private async Task AddData()
        {
            var paramDialog = new DialogParameters
            {
                { "Token", Token }
            };

            var dialog = _DialogService.Show<DialogAddUser>("Tambah Data User", paramDialog, new DialogOptions { MaxWidth = MaxWidth.Small });
            var dialogResult = await dialog.Result;
            if (!dialogResult.Canceled)
            {
                _Snackbar.ShowSuccess("Add Data Berhasil!");
                _ = _Table.ReloadServerData();
            }
        }

        private async Task EditData(UserResponse model)
        {
            var paramDialog = new DialogParameters
            {
                { "Token", Token },
                { "DataEdit", model }
            };

            var dialog = _DialogService.Show<DialogUser>("Ubah Data User", paramDialog, new DialogOptions { MaxWidth = MaxWidth.Small });
            var dialogResult = await dialog.Result;
            if (!dialogResult.Canceled)
            {
                _Snackbar.ShowSuccess("Ubah Data Berhasil!");
                _ = _Table.ReloadServerData();
            }
        }
        private void EditRole(UserResponse model)
        {
            var paramDialog = new DialogParameters
            {
                { "Token", Token },
                { "_IdUser", model.Id },
                { "_CanEdit", StaticMethod.CheckPermission(PermissionEnum.EDIT, Permission) }
            };

            _ = _DialogService.Show<DialogUserRole>("Ubah Data Role", paramDialog, new DialogOptions { MaxWidth = MaxWidth.Small });
        }
        private async Task Lock(UserResponse model, bool Value)
        {
            var confirm = await _DialogService.ShowMessageBox("Konfirmasi", "Apakah Anda Yakin?", yesText: "Ya", noText: "Tidak", options: new DialogOptions { MaxWidth = MaxWidth.ExtraSmall });
            if (confirm == null || !confirm.Value)
                return;

            _TableIsLoading = true;
            StateHasChanged();
            try
            {
                var res = await _UserService.Lock(model.Id,Value, Token.BaseApiUrl, Token.RawToken);
                if (res.Succeeded)
                {
                    _Snackbar.ShowSuccess("Data Berhasil Dirubah..");
                    _ = _Table.ReloadServerData();
                }
                else
                    _Snackbar.ShowError($"Error While Request :: {res.GetErrorMessage()}");
            }
            catch (Exception ex)
            {
                _Snackbar.ShowError($"Error at DeleteData :: {ex.Message}");
            }

            _TableIsLoading = false;
            StateHasChanged();
        }

        private async Task Active(UserResponse model,bool Value)
        {
            var confirm = await _DialogService.ShowMessageBox("Konfirmasi", "Apakah Anda Yakin?", yesText: "Ya", noText: "Tidak", options: new DialogOptions { MaxWidth = MaxWidth.ExtraSmall });
            if (confirm == null || !confirm.Value)
                return;

            _TableIsLoading = true;
            StateHasChanged();
            try
            {
                var res = await _UserService.Active(model.Id, Value, Token.BaseApiUrl, Token.RawToken);
                if (res.Succeeded)
                {
                    _Snackbar.ShowSuccess("Data Berhasil Dirubah..");
                    _ = _Table.ReloadServerData();
                }
                else
                    _Snackbar.ShowError($"Error While Request :: {res.GetErrorMessage()}");
            }
            catch (Exception ex)
            {
                _Snackbar.ShowError($"Error at DeleteData :: {ex.Message}");
            }

            _TableIsLoading = false;
            StateHasChanged();
        }

        private async Task Delete(UserResponse model)
        {
            var confirm = await _DialogService.ShowMessageBox("Konfirmasi", "Apakah Anda Yakin?", yesText: "Ya", noText: "Tidak", options: new DialogOptions { MaxWidth = MaxWidth.ExtraSmall });
            if (confirm == null || !confirm.Value)
                return;

            _TableIsLoading = true;
            StateHasChanged();
            try
            {
                var res = await _UserService.Delete(model.Id, Token.BaseApiUrl, Token.RawToken);
                if (res.Succeeded)
                {
                    _Snackbar.ShowSuccess("Data Berhasil Dihapus..");
                    _ = _Table.ReloadServerData();
                }
                else
                    _Snackbar.ShowError($"Error While Request :: {res.GetErrorMessage()}");
            }
            catch (Exception ex)
            {
                _Snackbar.ShowError($"Error at DeleteData :: {ex.Message}");
            }

            _TableIsLoading = false;
            StateHasChanged();
        }

        private async Task ChangePassword(UserResponse model)
        {
            var confirm = await _DialogService.ShowMessageBox("Konfirmasi", "Apakah Anda Yakin?", yesText: "Ya", noText: "Tidak", options: new DialogOptions { MaxWidth = MaxWidth.ExtraSmall });
            if (confirm == null || !confirm.Value)
                return;

            _TableIsLoading = true;
            StateHasChanged();
            try
            {
                var res = await _UserService.ResetPassword(model.Id, Token.BaseApiUrl, Token.RawToken);
                if (res.Succeeded)
                {
                    _Snackbar.ShowSuccess("Data Password Berhasil Direset..");
                    _ = _Table.ReloadServerData();
                }
                else
                    _Snackbar.ShowError($"Error While Request :: {res.GetErrorMessage()}");
            }
            catch (Exception ex)
            {
                _Snackbar.ShowError($"Error at Reset Password :: {ex.Message}");
            }

            _TableIsLoading = false;
            StateHasChanged();
        }
        private async Task ForceLogoff(UserResponse model)
        {
            var confirm = await _DialogService.ShowMessageBox("Konfirmasi", "Apakah Anda Yakin?", yesText: "Ya", noText: "Tidak", options: new DialogOptions { MaxWidth = MaxWidth.ExtraSmall });
            if (confirm == null || !confirm.Value)
                return;

            _Snackbar.ShowSuccess("User Berhasil di logoff..");
            await _HubService.SendLogoff(model.Username, "Device anda dipaksa untuk melakukan logout oleh administrator!");
        }
        #endregion

    }
}
