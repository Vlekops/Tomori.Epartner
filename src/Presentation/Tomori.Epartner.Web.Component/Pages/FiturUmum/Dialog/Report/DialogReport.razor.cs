namespace Tomori.Epartner.Web.Component.Pages.FiturUmum.Dialog.Report
{
    public partial class DialogReport : ComponentBase
    {
        #region Override
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (DataEdit != null)
                {
                    _Modul = DataEdit.Modul;
                    _Name = DataEdit.Name;
                    _Description = DataEdit.Description;
                    _Query = DataEdit.Query;
                    _Active = DataEdit.Active;

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
        private IReportService _Service { get; set; }
        [CascadingParameter]
        private MudDialogInstance _MudDialog { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        [Parameter]
        public ReportDetailResponse DataEdit { get; set; }
        #endregion

        #region Field
        private MudForm _Form;
        private bool _FormIsValid;
        private bool _FormIsLoading;

        private string _Modul = string.Empty;
        private string _Name = string.Empty;
        private string _Description = string.Empty;
        private string _Query = string.Empty;
        private bool _Active = true;
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
                var param = new ReportRequest
                {
                    Description = _Description,
                    Modul = _Modul,
                    Name = _Name,
                    Query = _Query,
                    Active = _Active
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
