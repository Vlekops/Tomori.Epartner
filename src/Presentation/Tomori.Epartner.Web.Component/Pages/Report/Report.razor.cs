

using Tomori.Epartner.Web.Component.Pages.FiturUmum.Dialog.Report;
using Tomori.Epartner.Web.Component.Pages.Report.Dialog;

namespace Tomori.Epartner.Web.Component.Pages.Report
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
        private IJSRuntime _Js { get; set; }
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
        private bool _ButtonCSVLoading = false;
        private bool _ButtonXLSLoading = false;

        private MudTable<TableRowWrapper<ReportResponse>> _Table;
        private List<string> _Category = new();
        private string _SelectedCategory = string.Empty;
        private string _Search = string.Empty;
        #endregion

        #region Method
        private async Task<TableData<TableRowWrapper<ReportResponse>>> ListData(TableState state)
        {
            var result = new TableData<TableRowWrapper<ReportResponse>>
            {
                Items = new List<TableRowWrapper<ReportResponse>>(),
                TotalItems = 0
            };

            _TableIsLoading = true;
            StateHasChanged();

            try
            {
                var start = state.Page + 1;
                var length = state.PageSize;

                var res = await _Service.List(_SelectedCategory, _Search,start,length, Token.BaseApiUrl, Token.RawToken);

                if (res.Succeeded)
                {
                    result.Items = res.List.GenerateRowNumber(StaticMethod.GetStartRowNumber(start, length)).ToList();
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
                var res = await _Service.ListCategory(false,Token.BaseApiUrl, Token.RawToken);
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

        private async Task Download(ReportResponse model,bool is_csv)
        {
            if (is_csv)
                _ButtonCSVLoading = true;
            else
                _ButtonXLSLoading = true;
            StateHasChanged();
            try
            {
                var param = new ExportReportRequest()
                {
                    Id = model.Id,
                    Parameter = null,
                };
                if (model.Parameter.Count>0)
                {
                    var paramDialog = new DialogParameters
                    {
                        { "Parameter", model.Parameter }
                    };

                    var dialog = _DialogService.Show<DialogReportParameter>("Parameter", paramDialog, new DialogOptions { MaxWidth = MaxWidth.Small });
                    var dialogResult = await dialog.Result;
                    if (dialogResult.Canceled)
                    {
                        if (is_csv)
                            _ButtonCSVLoading = false;
                        else
                            _ButtonXLSLoading = false;
                        StateHasChanged();
                        return;
                    }
                    param.Parameter = (Dictionary<string,string>)dialogResult.Data;
                }
                var res = new ObjectResponse<FileObject>();
                if (is_csv)
                    res = await _Service.ExportCsv(param, Token.BaseApiUrl, Token.RawToken);
                else
                    res = await _Service.Export(param, Token.BaseApiUrl, Token.RawToken);

                if (res.Succeeded)
                {
                    await _Js.DownloadFile(res.Data.Filename, res.Data.MimeType, res.Data.Base64);
                }
                else
                    _Snackbar.ShowError($"Error While Request :: {res.GetErrorMessage()}");
            }
            catch(Exception ex)
            {
                _Snackbar.ShowError($"Error at DeleteData :: {ex.Message}");
            }

            if (is_csv)
                _ButtonCSVLoading = false;
            else
                _ButtonXLSLoading = false;
            StateHasChanged();
        }

        #endregion
    }
}
