using Tomori.Epartner.Web.Component.Pages.FiturUmum.Dialog.Workflow;

namespace Tomori.Epartner.Web.Component.Pages.FiturUmum
{
    public partial class Workflow : ComponentBase
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
        private IWorkflowConfigService _Service { get; set; }
        [Inject]
        private NavigationManager _NavManager { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        [Parameter]
        public List<string> Permission { get; set; }
        #endregion

        #region Field
        private bool _TableIsLoading = false;
        private MudDataGrid<TableRowWrapper<WorkflowConfigResponse>> _Table;

        #endregion

        #region Method
        private async Task<GridData<TableRowWrapper<WorkflowConfigResponse>>> GetDataTable(GridState<TableRowWrapper<WorkflowConfigResponse>> state)
        {
            var result = new GridData<TableRowWrapper<WorkflowConfigResponse>>
            {
                Items = new List<TableRowWrapper<WorkflowConfigResponse>>(),
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

                var res = await _Service.List(param, Token.BaseApiUrl, Token.RawToken);

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

            var dialog = _DialogService.Show<DialogWorkflow>("Tambah Data Workflow", paramDialog, new DialogOptions { MaxWidth = MaxWidth.Small });
            var dialogResult = await dialog.Result;
            if (!dialogResult.Canceled)
            {
                _Snackbar.ShowSuccess("Add Data Berhasil!");
                _ = _Table.ReloadServerData();
            }
        }

        private async Task EditData(WorkflowConfigResponse model)
        {
            var paramDialog = new DialogParameters
            {
                { "Token", Token },
                { "DataEdit", model }
            };

            var dialog = _DialogService.Show<DialogWorkflow>("Ubah Data Workflow", paramDialog, new DialogOptions { MaxWidth = MaxWidth.Small });
            var dialogResult = await dialog.Result;
            if (!dialogResult.Canceled)
            {
                _Snackbar.ShowSuccess("Ubah Data Berhasil!");
                _ = _Table.ReloadServerData();
            }
        }

        private async Task DeleteData(WorkflowConfigResponse data)
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

        private void Detail(WorkflowConfigResponse model)
        {
            var paramDialog = new DialogParameters
            {
                { "Token", Token },
                { "_IdConfig", model.Id },
                { "_CanEdit", StaticMethod.CheckPermission(PermissionEnum.EDIT, Permission) }
            };

            _DialogService.Show<DialogDetailWorkflow>("Detail Data Workflow", paramDialog, new DialogOptions { MaxWidth = MaxWidth.ExtraLarge });
        }
        #endregion

    }
}
