
namespace Tomori.Epartner.Web.Component.Pages.FiturUmum.Dialog.Workflow
{
    public partial class DialogEditDetailWorkflow : ComponentBase
    {
        #region Override
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (_DataEdit != null)
                {
                    _StepNo = _DataEdit.StepNo;
                    _StepName = _DataEdit.StepName;
                    _ = GetUser(_DataEdit.User.Id);
                    _IsReviewer = _DataEdit.IsReviewer;
                    _CanAdhoc = _DataEdit.CanAdhoc;
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
        private IWorkflowConfigDetailService _Service { get; set; }
        [Inject]
        private IUserService _UserService { get; set; }
        [CascadingParameter]
        private MudDialogInstance _MudDialog { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        [Parameter]
        public Guid _IdConfig { get; set; }
        [Parameter]
        public WorkflowConfigDetailResponse _DataEdit { get; set; }
        #endregion

        #region Field
        private MudForm _Form;
        private bool _FormIsValid;
        private bool _FormIsLoading;

        private MudAutocomplete<UserResponse> _UserElement;
        private UserResponse _UserSelected = null;
        private bool _UserIsLoading = false;


        private int _StepNo = 1;
        private string _StepName = string.Empty;
        private bool _IsReviewer = false;
        private bool _CanAdhoc = false;
        //private DateTime? _Expired;
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
                var param = new WorkflowConfigDetailRequest()
                {
                    AutoApproveExpired = null,
                    CanAdhoc = _CanAdhoc,
                    IdUser = _UserSelected.Id,
                    IdWorkflowConfig = _IdConfig,
                    IsReviewer = _IsReviewer,
                    StepName = _StepName,
                    StepNo = _StepNo
                };

                StatusResponse res = null;
                if (_DataEdit == null)
                    res = await _Service.Add(param, Token.BaseApiUrl, Token.RawToken);
                else
                    res = await _Service.Edit(_DataEdit.Id, param, Token.BaseApiUrl, Token.RawToken);

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

        private async Task GetUser(Guid id_user)
        {
            _UserIsLoading = true;
            StateHasChanged();
            try
            {
                var result = await _UserService.Get(id_user, Token.BaseApiUrl, Token.RawToken);
                if (!result.Succeeded)
                {
                    _Snackbar.ShowError(result.Message);
                    return;
                }
                _UserSelected = result.Data;

                _UserIsLoading = false;

                StateHasChanged();

                if (_UserElement.Error)
                    _UserElement.ResetValidation();
            }
            catch (Exception ex)
            {
                _Snackbar.ShowError(ex.Message);
            }
        }
        #endregion
    }
}
