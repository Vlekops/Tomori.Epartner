using Tomori.Epartner.Web.Component.Pages.FiturUmum.Dialog;

namespace Tomori.Epartner.Web.Component.Pages.FiturUmum
{
    public partial class Role : ComponentBase
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
        private IDialogService _DialogService { get; set; }
        [Inject]
        private IRoleService _RoleService { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        [Parameter]
        public List<string> Permission { get; set; }
        #endregion

        #region Field
        private bool _TableIsLoading = false;
        private MudDataGrid<TableRowWrapper<RoleResponse>> _Table;

        #endregion

        #region Method
        private async Task<GridData<TableRowWrapper<RoleResponse>>> GetDataTable(GridState<TableRowWrapper<RoleResponse>> state)
        {
            var result = new GridData<TableRowWrapper<RoleResponse>>
            {
                Items = new List<TableRowWrapper<RoleResponse>>(),
                TotalItems = 0
            };

            _TableIsLoading = true;
            StateHasChanged();

            try
            {
                int start = state.Page + 1;
                var res = await _RoleService.Get(start, state.PageSize, Token.BaseApiUrl, Token.RawToken);

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

        private void AddPermission(RoleResponse model)
        {
            var paramDialog = new DialogParameters
            {
                { "Token", Token },
                { "IdRole", model.Id }
            };
            _DialogService.Show<DialogRolePermission>($"Role Permission - {model.Name}", paramDialog, new DialogOptions { MaxWidth = MaxWidth.Medium });
        }

        private async Task AddData()
        {
            var paramDialog = new DialogParameters
            {
                { "Token", Token }
            };

            var dialog = _DialogService.Show<DialogRole>("Tambah Data Role", paramDialog, new DialogOptions { MaxWidth = MaxWidth.Small });
            var dialogResult = await dialog.Result;
            if (!dialogResult.Canceled)
            {
                _Snackbar.ShowSuccess("Add Data Berhasil!");
                _ = _Table.ReloadServerData();
            }
        }

        private async Task EditData(RoleResponse model)
        {
            var paramDialog = new DialogParameters
            {
                { "Token", Token },
                { "DataEdit", model }
            };

            var dialog = _DialogService.Show<DialogRole>("Ubah Data Document Template", paramDialog, new DialogOptions { MaxWidth = MaxWidth.Small });
            var dialogResult = await dialog.Result;
            if (!dialogResult.Canceled)
            {
                _Snackbar.ShowSuccess("Ubah Data Berhasil!");
                _ = _Table.ReloadServerData();
            }
        }

        private async Task DeleteData(RoleResponse data)
        {
            var confirm = await _DialogService.ShowMessageBox("Konfirmasi", "Apakah Anda Yakin?", yesText: "Ya", noText: "Tidak", options: new DialogOptions { MaxWidth = MaxWidth.ExtraSmall });
            if (confirm == null || !confirm.Value)
                return;

            _TableIsLoading = true;
            StateHasChanged();

            try
            {
                var res = await _RoleService.Delete(data.Id, Token.BaseApiUrl, Token.RawToken);
                if (res.Succeeded)
                {
                    _Snackbar.ShowSuccess("Data Berhasil Hapus..");
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
        #endregion

    }
}
