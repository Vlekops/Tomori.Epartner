namespace Tomori.Epartner.Web.Component.Pages.FiturUmum.AuditList.Dialog
{
    public partial class DialogDetailChangeLog : ComponentBase
    {

        #region Inject, Cascading, Parameter
        [Inject]
        private ISnackbar _Snackbar { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        [Parameter]
        public List<ChangeLogPropertyResponse> Properties { get; set; }
        #endregion

        #region Field
        private MudDataGrid<TableRowWrapper<ChangeLogPropertyResponse>> _TableDetail;
        private bool _TableDetailIsLoading = false;
        #endregion

        #region Method
        private async Task<GridData<TableRowWrapper<ChangeLogPropertyResponse>>> GetListDataDetail(GridState<TableRowWrapper<ChangeLogPropertyResponse>> state)
        {
            await Task.Delay(100); // Nanti hapus

            var result = new GridData<TableRowWrapper<ChangeLogPropertyResponse>>
            {
                Items = new List<TableRowWrapper<ChangeLogPropertyResponse>>(),
                TotalItems = 0
            };

            _TableDetailIsLoading = true;
            StateHasChanged();

            try
            {
                var res = Properties;

                if (res != null)
                {
                    result.Items = Properties.GenerateRowNumber(StaticMethod.GetStartRowNumber(0, 0)).ToList();
                }
                else
                    _Snackbar.ShowError($"Error While Request");
            }
            catch (Exception ex)
            {
                _Snackbar.ShowError($"Error at GetDataTable :: {ex.Message}");
            }

            _TableDetailIsLoading = false;
            StateHasChanged();

            return result;
        }
        #endregion
    }
}
