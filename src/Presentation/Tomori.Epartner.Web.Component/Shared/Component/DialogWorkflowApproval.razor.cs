namespace Tomori.Epartner.Web.Component.Shared.Component
{
    public partial class DialogWorkflowApproval : ComponentBase
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
        private IWorkflowService _WorkflowService { get; set; }
        [CascadingParameter]
        private MudDialogInstance _MudDialog { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        [Parameter]
        public Guid IdWorkflow { get; set; }
        [Parameter]
        public bool? IsApprove { get; set; }
        #endregion

        #region Field
        private MudForm _Form;
        private bool _FormIsValid;
        private bool _FormIsLoading;

        private string _Notes = string.Empty;
        #endregion

        #region Method

        private async Task Save()
        {
            await _Form.Validate();

            if (!_FormIsValid)
            {
                _Snackbar.ShowWarning("Ada Beberapa Field Yang Belum Terisi!");
                return;
            }

            if (!await _DialogService.Confirm())
                return;

            _FormIsLoading = true;
            StateHasChanged();

            try
            {
                var param = new ApprovalWorkflowRequest
                {
                    IdWorkflow = IdWorkflow,
                    IsApprove = IsApprove.HasValue?IsApprove.Value:true,
                    Notes = _Notes
                };

                StatusResponse res =  await _WorkflowService.Approval(param, Token.BaseApiUrl, Token.RawToken);
                if (res != null && res.Succeeded)
                    _MudDialog.Close(DialogResult.Ok(true));
                else if (res != null && !res.Succeeded)
                    _Snackbar.ShowError($"Error While Request :: {res.GetErrorMessage()}");
                else if (res == null)
                    _Snackbar.ShowError("Something Went Wrong! Response is Null!");
            }
            catch (Exception ex)
            {
                _Snackbar.ShowError($"Error at Save :: {ex.Message}");
            }

            _FormIsLoading = false;
            StateHasChanged();
        }
        #endregion
    }
}
