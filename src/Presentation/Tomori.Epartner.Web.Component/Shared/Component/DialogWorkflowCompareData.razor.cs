namespace Tomori.Epartner.Web.Component.Shared.Component
{
    public partial class DialogWorkflowCompareData : ComponentBase
    {
        #region Override
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _ = GetData();
            }

            await base.OnAfterRenderAsync(firstRender);
        }
        #endregion

        #region Inject, Cascading, Parameter
        [Inject]
        private ISnackbar _Snackbar { get; set; }
        [Inject]
        private IWorkflowService _WorkflowService { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        [Parameter]
        public string WorkflowCode { get; set; }
        [Parameter]
        public string Code { get; set; }
        [Parameter]
        public Dictionary<string, Dictionary<string, string>> AliasFieldName { get; set; } = new Dictionary<string, Dictionary<string, string>>();
        #endregion

        #region Field
        private List<CompareDataWrapper> _Items = new List<CompareDataWrapper>();
        private bool _IsLoading = false;
        #endregion

        #region Method
        private async Task GetData()
        {
            _IsLoading = true;
            StateHasChanged();

            try
            {
                var res = await _WorkflowService.GetDataStatusProcess(WorkflowCode, Code, Token.BaseApiUrl, Token.RawToken);
                if (res.Succeeded)
                {
                    if (res.Data != null)
                        _Items = JsonConvert.DeserializeObject<List<CompareDataWrapper>>(res.Data);
                }
                else
                    _Snackbar.ShowError($"Error While Request at GetData :: {res.GetErrorMessage()}");
            }
            catch (Exception ex)
            {
                _Snackbar.ShowError($"Error at GetData :: {ex.Message}");
            }

            _IsLoading = false;
            StateHasChanged();
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
