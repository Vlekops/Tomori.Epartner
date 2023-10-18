
namespace Tomori.Epartner.Web.Component.Pages.FiturUmum.Dialog.Report
{
    public partial class DialogRoleReport : ComponentBase
    {
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
        public Guid _IdReport { get; set; }
        [Parameter]
        public bool _CanEdit { get; set; }
        #endregion

        #region Field
        private MudForm _Form;
        private bool _FormIsValid;
        private bool _FormIsLoading;

        private HashSet<TableRowWrapper<ReportRoleResponse>> SelectedItems = new HashSet<TableRowWrapper<ReportRoleResponse>>();
        private IEnumerable<TableRowWrapper<ReportRoleResponse>> _DataTable = new List<TableRowWrapper<ReportRoleResponse>>();

        private MudTable<TableRowWrapper<ReportRoleResponse>> _Table;
        private bool _TableIsLoading = false;
        #endregion

        #region Method

        private async Task<TableData<TableRowWrapper<ReportRoleResponse>>> GetDataTable(TableState state)
        {
            var result = new TableData<TableRowWrapper<ReportRoleResponse>>
            {
                Items = new List<TableRowWrapper<ReportRoleResponse>>(),
                TotalItems = 0
            };

            _TableIsLoading = true;
            StateHasChanged();

            try
            {
                int start = state.Page + 1;
                int length = state.PageSize;

                var res = await _Service.ListRole(_IdReport, true, start, length, Token.BaseApiUrl, Token.RawToken);

                if (res.Succeeded)
                {
                    result.Items = res.List.GenerateRowNumber(StaticMethod.GetStartRowNumber(start, length)).ToList();
                    result.TotalItems = res.Count ?? 0;
                    _DataTable = result.Items;
                    SelectedItems = result.Items.Where(d => d.Data.IsActive).ToHashSet();
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

        private async Task Save()
        {
            var confirm = await _DialogService.ShowMessageBox("Konfirmasi", "Apakah Anda Yakin?", yesText: "Ya", noText: "Tidak", options: new DialogOptions { MaxWidth = MaxWidth.ExtraSmall });
            if (confirm == null || !confirm.Value)
                return;
            _TableIsLoading = true;
            StateHasChanged();

            try
            {
                var param = new ReportRoleRequest()
                {
                    IdReport = _IdReport,
                    IdRoles = SelectedItems.Select(d => d.Data.IdRole).ToList()
                };
                Console.WriteLine(param);
                var res = await _Service.AddRole(param, Token.BaseApiUrl, Token.RawToken);
                if (res.Succeeded)
                {
                    _Snackbar.ShowSuccess("Data Berhasil Disimpan..");
                    _MudDialog.Close(DialogResult.Ok(true));
                }
                else
                    _Snackbar.ShowError($"Error While Request :: {res.GetErrorMessage()}");
            }
            catch (Exception ex)
            {
                _Snackbar.ShowError($"Error at DeleteData :: {ex.Message}");
            }

            _TableIsLoading = false;
            StateHasChanged();
        }
        #endregion
    }
}
