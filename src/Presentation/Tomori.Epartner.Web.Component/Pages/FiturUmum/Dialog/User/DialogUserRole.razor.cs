using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Pages.FiturUmum.Dialog.User
{
    public partial class DialogUserRole : ComponentBase
    {
        #region Inject, Cascading, Parameter
        [Inject]
        private ISnackbar _Snackbar { get; set; }
        [Inject]
        private IDialogService _DialogService { get; set; }
        [Inject]
        private IUserService _Service { get; set; }
        [CascadingParameter]
        private MudDialogInstance _MudDialog { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        [Parameter]
        public Guid _IdUser { get; set; }
        [Parameter]
        public bool _CanEdit { get; set; }
        #endregion

        #region Field
        private MudForm _Form;
        private bool _FormIsValid;
        private bool _FormIsLoading;

        private HashSet<TableRowWrapper<UserRoleResponse>> SelectedItems = new HashSet<TableRowWrapper<UserRoleResponse>>();
        private IEnumerable<TableRowWrapper<UserRoleResponse>> _DataTable = new List<TableRowWrapper<UserRoleResponse>>();

        private MudTable<TableRowWrapper<UserRoleResponse>> _Table;
        private bool _TableIsLoading = false;
        #endregion

        #region Method

        private async Task<TableData<TableRowWrapper<UserRoleResponse>>> GetDataTable(TableState state)
        {
            var result = new TableData<TableRowWrapper<UserRoleResponse>>
            {
                Items = new List<TableRowWrapper<UserRoleResponse>>(),
                TotalItems = 0
            };

            _TableIsLoading = true;
            StateHasChanged();

            try
            {
                int start = state.Page + 1;
                int length = state.PageSize;

                var res = await _Service.ListRole(_IdUser, true, start, length, Token.BaseApiUrl, Token.RawToken);

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
                var param = new UserRoleRequest()
                {
                    IdUser = _IdUser,
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
