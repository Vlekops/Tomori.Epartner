namespace Tomori.Epartner.Web.Component.Pages.FiturUmum.Dialog.Workflow
{
    public partial class DialogWorkflow : ComponentBase
    {
        #region Override
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (DataEdit != null)
                {
                    _Code = DataEdit.Code;
                    _Name = DataEdit.Name;
                    _CallbackUrl = DataEdit.CallbackUrl;
                    _NavigationUrl = DataEdit.NavigationUrl;
                    _Active = DataEdit.Active;
                    _IsSequence = DataEdit.IsSequence;
                    StateHasChanged();
                }
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
        [CascadingParameter]
        private MudDialogInstance _MudDialog { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        [Parameter]
        public WorkflowConfigResponse DataEdit { get; set; }
        #endregion

        #region Field
        private MudForm _Form;
        private bool _FormIsValid;
        private bool _FormIsLoading;

        private string _Code = string.Empty;
        private string _Name = string.Empty;
        private string _CallbackUrl = string.Empty;
        private string _NavigationUrl = string.Empty;
        public bool _Active = true;
        public bool _IsSequence = true;
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

            var confirm = await _DialogService.ShowMessageBox("Konfirmasi", "Apakah Anda Yakin?", yesText: "Ya", noText: "Tidak", options: new DialogOptions { MaxWidth = MaxWidth.ExtraSmall });
            if (confirm == null || !confirm.Value)
                return;

            _FormIsLoading = true;
            StateHasChanged();
            try
            {
                var param = new WorkflowConfigRequest
                {
                    Code = _Code,
                    Name = _Name,
                    Active = _Active,
                    CallbackUrl = _CallbackUrl,
                    NavigationUrl = _NavigationUrl,
                    IsSequence = _IsSequence,
                };

                StatusResponse res = null;
                if (DataEdit == null)
                    res = await _Service.Add(param, Token.BaseApiUrl, Token.RawToken);
                else
                    res = await _Service.Edit(DataEdit.Id, param, Token.BaseApiUrl, Token.RawToken);

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
