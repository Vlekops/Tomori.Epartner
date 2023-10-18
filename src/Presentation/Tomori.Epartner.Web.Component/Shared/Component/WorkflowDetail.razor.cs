namespace Tomori.Epartner.Web.Component.Shared.Component
{
    public partial class WorkflowDetail : ComponentBase
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
        private IDialogService _DialogService { get; set; }
        [Inject]
        private IWorkflowService _WorkflowService { get; set; }
        [Inject]
        private IJSRuntime _JS { get; set; }
        [Inject]
        private NavigationManager _NavManager { get; set; }
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter]
        public RenderFragment ButtonAdditionalContent { get; set; }
        [Parameter]
        public string Code { get; set; }
        [Parameter]
        public List<string> WorkflowCode { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        [Parameter]
        public EventCallback<Dictionary<string, string>> OnDataLoaded { get; set; }
        #endregion

        #region Field Public 
        public string DataJson { get; set; }
        public string NoteApproval { get; set; }
        #endregion

        #region Field
        private bool _IsProcess = false;
        private WorkflowDetailResponse _Data = new();
        #endregion

        #region Method
        private async Task GetData()
        {
            await _JS.ShowBodyLoading(true);

            try
            {
                var res = await _WorkflowService.Detail(new WorkflowDetailRequest
                {
                    WorkflowCode = WorkflowCode,
                    Code = Code
                }, Token.BaseApiUrl, Token.RawToken);
                if (res.Succeeded)
                {
                    _Data = res.Data;
                    _IsProcess = res.Data.Workflow.Any(_ => _.CurrentWorkflow && _.StatusCode == 0 && _.Detail.Any(__ => __.CurrentStep && __.IdUser == Token.User.Id));
                    DataJson = res.Data.Workflow.Where(_ => _.CurrentWorkflow).Select(_ => _.Data).FirstOrDefault();
                    NoteApproval = res.Data.Workflow.Where(_ => _.CurrentWorkflow).SelectMany(_ => _.Detail).Where(_ => _.CurrentStep).Select(_ => _.Notes).FirstOrDefault();

                    StateHasChanged();

                    await OnDataLoaded.InvokeAsync(new Dictionary<string, string>
                    {
                        { "DataJson", DataJson },
                        { "NoteApproval", NoteApproval }
                    });
                }
                else
                    _Snackbar.ShowError($"Error While Request :: {res.GetErrorMessage()}");
            }
            catch (Exception ex)
            {
                _Snackbar.ShowError($"Error at GetDataTable :: {ex.Message}");
            }

            await _JS.ShowBodyLoading(false);
        }

        private async Task Delegate(bool is_delegate)
        {
            var paramDialog = new DialogParameters
            {
                { "Token", Token },
                { "IdWorkflow", _Data.IdWorkflow },
                { "IsAdhoc", !is_delegate }
            };
            string subject = is_delegate ? "Delegate User" : "Ad-Hoc User";
            var dialog = _DialogService.Show<DialogWorkflowDelegate>(subject, paramDialog, new DialogOptions { MaxWidth = MaxWidth.Small });
            var dialogResult = await dialog.Result;
            if (!dialogResult.Canceled)
            {
                _Snackbar.ShowSuccess("Success!");
                _NavManager.NavigateTo(_NavManager.Uri, true);
            }
        }

        private async Task Review()
        {
            var paramDialog = new DialogParameters
            {
                { "Token", Token },
                { "IdWorkflow", _Data.IdWorkflow }
            };

            var dialog = _DialogService.Show<DialogWorkflowApproval>("Review", paramDialog, new DialogOptions { MaxWidth = MaxWidth.Small });
            var dialogResult = await dialog.Result;
            if (!dialogResult.Canceled)
            {
                _Snackbar.ShowSuccess("Review Data Berhasil!");
                _NavManager.NavigateTo(_NavManager.Uri, true);
            }
        }

        private async Task Approval(bool is_approve)
        {
            var paramDialog = new DialogParameters
            {
                { "Token", Token },
                { "IdWorkflow", _Data.IdWorkflow },
                { "IsApprove", is_approve }
            };

            var dialog = _DialogService.Show<DialogWorkflowApproval>(is_approve ? "Approve" : "Reject", paramDialog, new DialogOptions { MaxWidth = MaxWidth.Small });
            var dialogResult = await dialog.Result;
            if (!dialogResult.Canceled)
            {
                _Snackbar.ShowSuccess("Success!");
                _NavManager.NavigateTo(_NavManager.Uri, true);
            }
        }

        private string SetMark(WorkflowDetailObject data)
        {
            string result = string.Empty;
            if (data.Status == WorkflowStatusEnum.Reject)
                result = "background: #f392a9 !important;";
            return result;
        }

        private string SetTitle(WorkflowObject obj)
        {
            string result = string.Empty;
            if (obj.WorkflowCode.EndsWith("REG"))
                result = "Registrasi";
            else if (obj.WorkflowCode.EndsWith("CRT"))
                result = "Pembentukan";
            else if (obj.WorkflowCode.EndsWith("UPD"))
                result = $"Perubahan Data - {obj.CreateDate:dd MMMM yyyy}";
            return result;
        }
        #endregion

    }
}
