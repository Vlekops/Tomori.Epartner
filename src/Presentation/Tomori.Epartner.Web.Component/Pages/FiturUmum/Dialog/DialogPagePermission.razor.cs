namespace Tomori.Epartner.Web.Component.Pages.FiturUmum.Dialog
{
    public partial class DialogPagePermission : ComponentBase
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
        public IDialogService _DialogService { get; set; }
        [Inject]
        private IPagePermissionService _PagePermissionService { get; set; }
        [CascadingParameter]
        private MudDialogInstance _MudDialog { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        [Parameter]
        public Guid IdPage { get; set; }
        #endregion

        #region Field
        private MudForm _Form;
        private bool _FormIsValid;
        private bool _FormIsLoading;

        private List<FilterSelect> _ListItems = new List<FilterSelect>
        {
            new FilterSelect(".view", "View"),
            new FilterSelect(".add", "Add"),
            new FilterSelect(".edit", "Edit"),
            new FilterSelect(".delete", "Delete"),
            new FilterSelect(".other", "Other")
        };
        private FilterSelect _ItemSelected;

        private Guid _Id = Guid.Empty;
        private string _Name = string.Empty;
        private bool _Active = true;
        private bool _IsAdd = true;

        private bool _TableIsLoading = false;
        private MudTable<TableRowWrapper<PagePermissionResponse>> _Table;
        #endregion

        #region Method
        private async Task Save()
        {
            await _Form.Validate();

            if (!_FormIsValid)
                return;

            var confirm = await _DialogService.ShowMessageBox("Konfirmasi", "Apakah Anda Yakin?", yesText: "Ya", noText: "Tidak", options: new DialogOptions { MaxWidth = MaxWidth.ExtraSmall });
            if (confirm == null || !confirm.Value)
                return;

            _FormIsLoading = true;
            StateHasChanged();

            try
            {
                var param = new PagePermissionRequest
                {
                    IdPage = IdPage,
                    Name = _ItemSelected?.Key == ".other" ? _Name : _ItemSelected.Key,
                    Active = _Active
                };

                StatusResponse res = null;
                if (_IsAdd)
                    res = await _PagePermissionService.Add(param, Token.BaseApiUrl, Token.RawToken);
                else
                    res = await _PagePermissionService.Edit(_Id, param, Token.BaseApiUrl, Token.RawToken);

                if (res != null && res.Succeeded)
                {
                    _Snackbar.ShowSuccess($"{(_IsAdd ? "Tambah" : "Ubah")} Data Berhasil!");

                    _ = _Form.ResetAsync();
                    _ = _Table.ReloadServerData();

                    _IsAdd = true;
                }
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

        private void ResetForm()
        {
            _ = _Form.ResetAsync();
            _Id = Guid.Empty;
            _IsAdd = true;
            StateHasChanged();
        }

        private async Task<TableData<TableRowWrapper<PagePermissionResponse>>> GetDataTable(TableState state)
        {
            var result = new TableData<TableRowWrapper<PagePermissionResponse>>
            {
                Items = new List<TableRowWrapper<PagePermissionResponse>>(),
                TotalItems = 0
            };

            _TableIsLoading = true;
            StateHasChanged();

            try
            {
                var param = new ListRequest
                {
                    Start = state.Page + 1,
                    Length = state.PageSize,
                    Filter = new List<FilterRequest>
                    {
                        new FilterRequest("idpage", IdPage.ToString())
                    },
                    Sort = new SortRequest(string.IsNullOrEmpty(state.SortLabel) ? "name" : state.SortLabel, state.SortDirection == SortDirection.None ? SortTypeEnum.ASC : state.SortDirection == SortDirection.Ascending ? SortTypeEnum.ASC : SortTypeEnum.DESC)
                };

                var res = await _PagePermissionService.List(param, Token.BaseApiUrl, Token.RawToken);

                if (res.Succeeded)
                {
                    result.Items = res.List.GenerateRowNumber(StaticMethod.GetStartRowNumber(param.Start.Value, param.Length.Value)).ToList();
                    result.TotalItems = res.Count ?? 0;
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

        private void EditDataMode(PagePermissionResponse data)
        {
            _Id = data.Id;
            _Name = string.Empty;
            var item = _ListItems.Where(d => d.Key.ToLower().Trim() == data.Name.Trim().ToLower()).FirstOrDefault();
            if (item == null)
            {
                item = _ListItems.Where(d => d.Key == ".other").FirstOrDefault();
                _Name = data.Name;
            }
            _ItemSelected = item;
            _Active = data.Active;
            _IsAdd = false;
            StateHasChanged();
        }

        private async Task DeleteData(PagePermissionResponse data)
        {
            var confirm = await _DialogService.ShowMessageBox("Konfirmasi", "Apakah Anda Yakin?", yesText: "Ya", noText: "Tidak", options: new DialogOptions { MaxWidth = MaxWidth.ExtraSmall });
            if (confirm == null || !confirm.Value)
                return;

            _TableIsLoading = true;
            StateHasChanged();

            try
            {
                var res = await _PagePermissionService.Delete(data.Id, Token.BaseApiUrl, Token.RawToken);
                if (res.Succeeded)
                {
                    _Snackbar.ShowSuccess("Hapus Data Berhasil!");
                    _ = _Table.ReloadServerData();
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
