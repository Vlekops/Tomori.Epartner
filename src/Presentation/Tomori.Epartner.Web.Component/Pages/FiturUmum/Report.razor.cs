using Tomori.Epartner.Web.Component.Pages.FiturUmum.Dialog.Report;

namespace Tomori.Epartner.Web.Component.Pages.FiturUmum
{
    public partial class Report : ComponentBase
    {
        #region Override
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await GetListCategory();
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
        private IReportService _Service { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        [Parameter]
        public List<string> Permission { get; set; }
        #endregion

        #region Field
        private bool _TableIsLoading = false;
        private MudDataGrid<TableRowWrapper<ReportDetailResponse>> _Table;
        private List<string> _Category = new();
        private string _selectedCategory = string.Empty;
        #endregion

        #region Method
        private async Task<GridData<TableRowWrapper<ReportDetailResponse>>> GetDataTable(GridState<TableRowWrapper<ReportDetailResponse>> state)
        {
            var result = new GridData<TableRowWrapper<ReportDetailResponse>>
            {
                Items = new List<TableRowWrapper<ReportDetailResponse>>(),
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
                    Filter = new List<FilterRequest>()
                    {
                        new FilterRequest()
                        {
                            Field = "modul",
                            Search = _selectedCategory
                        }
                    },
                    Sort = new SortRequest("createdate", SortTypeEnum.DESC)
                };

                if (state.SortDefinitions.Any())
                {
                    var obj = state.SortDefinitions.FirstOrDefault();
                    param.Sort = new SortRequest(obj.SortBy, obj.Descending ? SortTypeEnum.DESC : SortTypeEnum.ASC);
                }

                var res = await _Service.ListDetail(param, Token.BaseApiUrl, Token.RawToken);

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

        private async Task GetListCategory()
        {
            var result = new List<string>();
            try
            {
                var res = await _Service.ListCategory(true,Token.BaseApiUrl, Token.RawToken);
                if (res.Succeeded)
                {
                    _Category = res.List;
                }
            }
            catch (Exception ex)
            {
                _Snackbar.ShowError($"Error at GetDataTable :: {ex.Message}");
            }
        }

        private async Task AddData()
        {
            var paramDialog = new DialogParameters
            {
                { "Token", Token }
            };

            var dialog = _DialogService.Show<DialogReport>("Tambah Data Report", paramDialog, new DialogOptions { MaxWidth = MaxWidth.Small });
            var dialogResult = await dialog.Result;
            if (!dialogResult.Canceled)
            {
                _Snackbar.ShowSuccess("Tambah Data Berhasil!");
                _ = _Table.ReloadServerData();
            }
        }

        private async Task EditData(ReportDetailResponse model)
        {
            var paramDialog = new DialogParameters
            {
                { "Token", Token },
                { "DataEdit", model }
            };

            var dialog = _DialogService.Show<DialogReport>("Ubah Data Report", paramDialog, new DialogOptions { MaxWidth = MaxWidth.Small });
            var dialogResult = await dialog.Result;
            if (!dialogResult.Canceled)
            {
                _Snackbar.ShowSuccess("Ubah Data Berhasil!");
                _ = _Table.ReloadServerData();
            }
        }
        private void RoleData(ReportDetailResponse model)
        {
            var paramDialog = new DialogParameters
            {
                { "Token", Token },
                { "_IdReport", model.Id },
                { "_CanEdit", StaticMethod.CheckPermission(PermissionEnum.EDIT, Permission) }
            };
            _ = _DialogService.Show<DialogRoleReport>("Ubah Data Role Report", paramDialog, new DialogOptions { MaxWidth = MaxWidth.Small });
        }

        private async Task DeleteData(ReportDetailResponse data)
        {
            var confirm = await _DialogService.ShowMessageBox("Konfirmasi", "Apakah Anda Yakin?", yesText: "Ya", noText: "Tidak", options: new DialogOptions { MaxWidth = MaxWidth.ExtraSmall });
            if (confirm == null || !confirm.Value)
                return;

            _TableIsLoading = true;
            StateHasChanged();

            try
            {
                var res = await _Service.Delete(data.Id, Token.BaseApiUrl, Token.RawToken);
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
