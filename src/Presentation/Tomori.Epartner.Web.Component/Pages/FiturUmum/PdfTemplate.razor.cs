using Tomori.Epartner.Web.Component.Pages.FiturUmum.Dialog;

namespace Tomori.Epartner.Web.Component.Pages.FiturUmum
{
    public partial class PdfTemplate : ComponentBase
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
        private IPdfTemplateService _Service { get; set; }
        [Inject]
        private NavigationManager _NavManager { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        [Parameter]
        public List<string> Permission { get; set; }
        #endregion

        #region Field
        private bool _TableIsLoading = false;
        private MudDataGrid<TableRowWrapper<PdfTemplateResponse>> _Table;

        #endregion

        #region Method
        private async Task<GridData<TableRowWrapper<PdfTemplateResponse>>> GetDataTable(GridState<TableRowWrapper<PdfTemplateResponse>> state)
        {
            var result = new GridData<TableRowWrapper<PdfTemplateResponse>>
            {
                Items = new List<TableRowWrapper<PdfTemplateResponse>>(),
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

            var dialog = _DialogService.Show<DialogPdfTemplate>("Tambah Data PDF Template", paramDialog, DialogWidth.XL);
            var dialogResult = await dialog.Result;
            if (!dialogResult.Canceled)
            {
                _Snackbar.ShowSuccess("Add Data Berhasil!");
                _ = _Table.ReloadServerData();
            }
        }

        private async Task EditData(PdfTemplateResponse model)
        {
            var paramDialog = new DialogParameters
            {
                { "Token", Token },
                { "DataEdit", model }
            };

            var dialog = _DialogService.Show<DialogPdfTemplate>("Ubah Data PDF Template", paramDialog, DialogWidth.XL);
            var dialogResult = await dialog.Result;
            if (!dialogResult.Canceled)
            {
                _Snackbar.ShowSuccess("Ubah Data Berhasil!");
                _ = _Table.ReloadServerData();
            }
        }

        private async Task DeleteData(PdfTemplateResponse data)
        {
            if (!await _DialogService.Confirm())
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
