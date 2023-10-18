namespace Tomori.Epartner.Web.Component.Shared.Component
{
    public partial class DialogWorkflowDelegate : ComponentBase
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
        [Inject]
        private IUserService _UserService { get; set; }
        [CascadingParameter]
        private MudDialogInstance _MudDialog { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        [Parameter]
        public Guid IdWorkflow { get; set; }
        [Parameter]
        public bool IsAdhoc { get; set; }
        #endregion

        #region Field
        private MudForm _Form;
        private bool _FormIsValid;
        private bool _FormIsLoading;

        private MudAutocomplete<UserResponse> _UserElement;
        private UserResponse _UserSelected = null;
        private bool _UserIsLoading = false;

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
                var param = new DelegateWorkflowRequest
                {
                    IdWorkflow = IdWorkflow,
                    Message = _Notes,
                    IdUser = _UserSelected.Id,
                    Tipe = IsAdhoc? DelegateTipeEnum.Adhoc: DelegateTipeEnum.Delegate
                };

                StatusResponse res =  await _WorkflowService.Delegate(param, Token.BaseApiUrl, Token.RawToken);
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

        #region User
        private async Task<IEnumerable<UserResponse>> SearchUser(string value)
        {
            var result = new List<UserResponse>();
            try
            {
                var param = new ListRequest
                {
                    Start = 1,
                    Length = 11,
                    Filter = new List<FilterRequest>(),
                    Sort = new SortRequest("id", SortTypeEnum.ASC)
                };

                if (!string.IsNullOrEmpty(value))
                    param.Filter.Add(new FilterRequest("id_name_description", value));

                var res = await _UserService.List(param, Token.BaseApiUrl, Token.RawToken);

                if (res.Succeeded)
                    result = res.List;
                else
                    _Snackbar.ShowError(res.GetErrorMessage());
            }
            catch (Exception ex)
            {
                _Snackbar.ShowError(ex.Message);
            }
            return result;
        }
        #endregion

        #endregion
    }
}
