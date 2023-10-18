
namespace Tomori.Epartner.Web.Component.Pages.FiturUmum.Dialog.Workflow
{
    public partial class DialogDetailWorkflow : ComponentBase
    {
        #region Inject, Cascading, Parameter
        [Inject]
        private ISnackbar _Snackbar { get; set; }
        [Inject]
        private IDialogService _DialogService { get; set; }
        [Inject]
        private IWorkflowConfigDetailService _DetailService { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        [Parameter]
        public Guid _IdConfig { get; set; }
        [Parameter]
        public bool _CanEdit { get; set; }
        #endregion

        #region Field
        private MudForm _Form;
        private bool _FormIsValid;
        private MudDataGrid<TableRowWrapper<WorkflowConfigDetailResponse>> _TableDetail;
        private bool _TableDetailIsLoading = false;
        #endregion

        #region Method
        private async Task<GridData<TableRowWrapper<WorkflowConfigDetailResponse>>> GetListDataDetail(GridState<TableRowWrapper<WorkflowConfigDetailResponse>> state)
        {
            var result = new GridData<TableRowWrapper<WorkflowConfigDetailResponse>>
            {
                Items = new List<TableRowWrapper<WorkflowConfigDetailResponse>>(),
                TotalItems = 0
            };

            _TableDetailIsLoading = true;
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
                            Field= "idworkflowconfig",
                            Search =_IdConfig.ToString()
                        }
                    },
                    Sort = new SortRequest("stepno", SortTypeEnum.ASC)
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

                var res = await _DetailService.List(param, Token.BaseApiUrl, Token.RawToken);

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

            _TableDetailIsLoading = false;
            StateHasChanged();

            return result;
        }

        private async Task AddDataDetail()
        {
            var dialogParameters = new DialogParameters
            {
                { "Token", Token },
                { "_IdConfig", _IdConfig }
            };
            var addDialog = _DialogService.Show<DialogEditDetailWorkflow>("Tambah Data Workflow", dialogParameters, new DialogOptions { MaxWidth = MaxWidth.Medium });
            var addDialogResult = await addDialog.Result;
            if (!addDialogResult.Canceled)
            {
                _Snackbar.ShowSuccess("Add Data Berhasil!");
                await _TableDetail.ReloadServerData();
            }
        }

        private async Task EditDataDetail(WorkflowConfigDetailResponse data)
        {
            var dialogParameters = new DialogParameters
            {
                { "Token", Token },
                { "_IdConfig", _IdConfig },
                { "_DataEdit", data }
            };
            var editDialog = _DialogService.Show<DialogEditDetailWorkflow>("Ubah Data Workflow", dialogParameters, new DialogOptions { MaxWidth = MaxWidth.Medium });
            var editDialogResult = await editDialog.Result;
            if (!editDialogResult.Canceled)
            {
                _Snackbar.ShowSuccess("Edit Data Berhasil!");
                await _TableDetail.ReloadServerData();
            }
        }

        private async Task DeleteDataDetail(Guid id)
        {
            var confirm = await _DialogService.ShowMessageBox("Konfirmasi", "Apakah Anda Yakin?", yesText: "Ya", noText: "Tidak", options: new DialogOptions { MaxWidth = MaxWidth.ExtraSmall });
            if (confirm == null || !confirm.Value)
                return;
            _TableDetailIsLoading = true;
            StateHasChanged();

            try
            {
                var res = await _DetailService.Delete(id, Token.BaseApiUrl, Token.RawToken);
                if (res.Succeeded)
                {
                    _Snackbar.ShowSuccess("Data Berhasil Hapus..");
                    _ = _TableDetail.ReloadServerData();
                }
                else
                    _Snackbar.ShowError($"Error While Request :: {res.GetErrorMessage()}");
            }
            catch (Exception ex)
            {
                _Snackbar.ShowError($"Error at DeleteData :: {ex.Message}");
            }

            _TableDetailIsLoading = false;
            StateHasChanged();
        }
        #endregion
    }
}
