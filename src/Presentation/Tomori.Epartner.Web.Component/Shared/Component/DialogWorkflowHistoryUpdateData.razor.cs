namespace Tomori.Epartner.Web.Component.Shared.Component
{
    public partial class DialogWorkflowHistoryUpdateData : ComponentBase
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
        private IWorkflowService _WorkflowService { get; set; }
        [Inject]
        private IJSRuntime _Js { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        [Parameter]
        public string Code { get; set; }
        [Parameter]
        public Dictionary<string, Dictionary<string, string>> AliasFieldName { get; set; } = new Dictionary<string, Dictionary<string, string>>();
        #endregion

        #region Field
        private bool _TableIsLoading = false;
        private MudDataGrid<TableRowWrapper<WorkflowUpdateDataHistoryResponse>> _Table;
        #endregion

        #region Method
        private async Task<GridData<TableRowWrapper<WorkflowUpdateDataHistoryResponse>>> GetDataTable(GridState<TableRowWrapper<WorkflowUpdateDataHistoryResponse>> state)
        {
            var result = new GridData<TableRowWrapper<WorkflowUpdateDataHistoryResponse>>
            {
                Items = new List<TableRowWrapper<WorkflowUpdateDataHistoryResponse>>(),
                TotalItems = 0
            };

            _TableIsLoading = true;
            StateHasChanged();

            try
            {
                var start = state.Page + 1;
                var res = await _WorkflowService.GetUpdateDataHistory(Code, start, state.PageSize, Token.BaseApiUrl, Token.RawToken);

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

        private int GetCountPerubahanData(string json)
        {
            int result = 0;
            var data = JsonConvert.DeserializeObject<List<CompareDataWrapper>>(json);
            result = data.Sum(_ => _.Items.Count);
            return result;
        }

        private MarkupString GetStatus(WorkflowEnum status)
        {
            string result = $@"<span class=""fw-semibold"">{status}</span>";
            if (status == WorkflowEnum.Approved)
                result = $@"<span class=""text-success fw-semibold"">Approved</span>";
            else if (status == WorkflowEnum.Reject)
                result = $@"<span class=""text-danger fw-semibold"">Rejected</span>";
            return new MarkupString(result);
        }

        private async Task DownloadFile(Guid id)
        {
            await _Js.InvokeVoidAsync("open", $"{Token.BaseApiUrl}/v1/Repository/download/{id}", "_blank");
        }

        private string GetField(string section, string field)
        {
            string result = field;
            if (AliasFieldName.TryGetValue(section, out Dictionary<string, string> value))
            {
                if (value.TryGetValue(field, out string _field))
                    result = _field;
            }
            return result;
        }

        private string GetValue(string type, string value)
        {
            string result = value;
            switch (type)
            {
                case "DateTime":
                    if (DateTime.TryParse(value, out DateTime parseResult))
                        result = parseResult.ToString("dd MMMM yyyy");
                    break;

                case "decimal":
                    if (decimal.TryParse(value, out decimal decimalParseResult))
                        result = decimalParseResult.ToCurrencyFormat();
                    break;
            }
            return result;
        }
        #endregion
    }
}
