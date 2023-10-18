namespace Tomori.Epartner.Web.Component.Pages.Report.Dialog
{
    public partial class DialogReportParameter : ComponentBase
    {
        #region Override
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _Parameter = Parameter.Select(d => new ParameterModel()
                {
                    Key = d,
                    Value = string.Empty
                }).ToList();
                StateHasChanged();
            }

            await base.OnAfterRenderAsync(firstRender);
        }
        #endregion

        #region Inject, Cascading, Parameter
        [Inject]
        private ISnackbar _Snackbar { get; set; }
        [CascadingParameter]
        private MudDialogInstance _MudDialog { get; set; }
        [Parameter]
        public List<string> Parameter { get; set; }
        #endregion

        #region Field
        private MudForm _Form;
        private bool _FormIsValid;

        private List<ParameterModel> _Parameter = new List<ParameterModel>();
        #endregion

        #region Method
        private async Task Submit()
        {
            await _Form.Validate();

            if (!_FormIsValid)
            {
                _Snackbar.ShowWarning("Ada Beberapa Field Yang Belum Terisi!");
                return;
            }
            var result = new Dictionary<string, string>();
            foreach(var data in _Parameter)
            {
                result.Add(data.Key, data.Value);
            }
            _MudDialog.Close(DialogResult.Ok(result));
        }
        #endregion
    }
}
