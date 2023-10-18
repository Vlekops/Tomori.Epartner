using System.Reflection;

namespace Tomori.Epartner.Web.Component.Pages.FiturUmum.Dialog
{
    public partial class DialogRolePermission : ComponentBase
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
        [Inject]
        public IDialogService _DialogService { get; set; }
        [Inject]
        private IPageService _PageService { get; set; }
        [Inject]
        private IRolePermissionService _RolePermissionService { get; set; }
        [CascadingParameter]
        private MudDialogInstance _MudDialog { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        [Parameter]
        public string IdRole { get; set; }
        #endregion

        #region Field
        private string _FilterSearch = string.Empty;

        private bool _TableIsLoading = false;
        private MudDataGrid<TableRowWrapper<PageByRoleResponse>> _Table;
        #endregion

        #region Method
        private void FilterSearchKeyPress(KeyboardEventArgs args)
        {
            if (args != null && args.Key != null && args.Key.Equals("Enter"))
            {
                _Table.ReloadServerData();
            }
        }

        private async Task<GridData<TableRowWrapper<PageByRoleResponse>>> GetDataTable(GridState<TableRowWrapper<PageByRoleResponse>> state)
        {
            var result = new GridData<TableRowWrapper<PageByRoleResponse>>
            {
                Items = new List<TableRowWrapper<PageByRoleResponse>>(),
                TotalItems = 0
            };

            _TableIsLoading = true;
            StateHasChanged();

            try
            {
                var start = state.Page + 1;
                var res = await _PageService.GetByRole(IdRole, _FilterSearch, start, state.PageSize, Token.BaseApiUrl, Token.RawToken);

                if (res.Succeeded)
                {
                    result.Items = res.List.GenerateRowNumber(StaticMethod.GetStartRowNumber(start, state.PageSize)).ToList();
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
                { "Token", Token },
                { "IdRole", IdRole }
            };
            var dialog = _DialogService.Show<DialogRolePermissionEditor>($"Tambah Permission", paramDialog, new DialogOptions { MaxWidth = MaxWidth.Medium });
            var dialogResult = await dialog.Result;
            if (!dialogResult.Canceled)
            {
                _Snackbar.ShowSuccess("Tambah Data Berhasil..");
                _ = _Table.ReloadServerData();
            }
        }

        private async Task EditData(PageByRoleResponse data)
        {
            var paramDialog = new DialogParameters
            {
                { "Token", Token },
                { "IdRole", IdRole },
                { "DataEdit", data }
            };
            var dialog = _DialogService.Show<DialogRolePermissionEditor>($"Ubah Permission", paramDialog, new DialogOptions { MaxWidth = MaxWidth.Medium });
            var dialogResult = await dialog.Result;
            if (!dialogResult.Canceled)
            {
                _Snackbar.ShowSuccess("Ubah Data Berhasil..");
                _ = _Table.ReloadServerData();
            }
        }

        private async Task DeleteData(PageByRoleResponse data)
        {
            var confirm = await _DialogService.ShowMessageBox("Konfirmasi", "Apakah Anda Yakin?", yesText: "Ya", noText: "Tidak", options: new DialogOptions { MaxWidth = MaxWidth.ExtraSmall });
            if (confirm == null || !confirm.Value)
                return;

            _TableIsLoading = true;
            StateHasChanged();

            try
            {
                var res = await _RolePermissionService.DeleteRange(IdRole, data.IdPage, Token.BaseApiUrl, Token.RawToken);
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

        private async Task DeletePermission(List<RolePermissionResponse> datas, RolePermissionResponse data)
        {
            var confirm = await _DialogService.ShowMessageBox("Konfirmasi", "Apakah Anda Yakin?", yesText: "Ya", noText: "Tidak", options: new DialogOptions { MaxWidth = MaxWidth.ExtraSmall });
            if (confirm == null || !confirm.Value)
                return;

            _TableIsLoading = true;
            StateHasChanged();

            try
            {
                var res = await _RolePermissionService.Delete(data.Id, Token.BaseApiUrl, Token.RawToken);
                if (res.Succeeded)
                {
                    _Snackbar.ShowSuccess("Data Berhasil Dihapus..");
                    datas.Remove(data);
                }
                else
                    _Snackbar.ShowError($"Error While Request :: {res.GetErrorMessage()}");
            }
            catch (Exception ex)
            {
                _Snackbar.ShowError($"Error at DeletePermission :: {ex.Message}");
            }

            _TableIsLoading = false;
            StateHasChanged();
        }
        #endregion
    }
}
