using static System.Collections.Specialized.BitVector32;

namespace Tomori.Epartner.Web.Component.Pages.FiturUmum.Dialog
{
    public partial class DialogRolePermissionEditor : ComponentBase
    {
        #region Override
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (DataEdit != null)
                {
                    _ = GetPage(DataEdit.IdPage);
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
        private IPageService _PageService { get; set; }
        [Inject]
        private IPagePermissionService _PagePermissionService { get; set; }
        [Inject]
        private IRolePermissionService _RolePermissionService { get; set; }
        [CascadingParameter]
        private MudDialogInstance _MudDialog { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        [Parameter]
        public string IdRole { get; set; }
        [Parameter]
        public PageByRoleResponse DataEdit { get; set; }
        #endregion

        #region Field
        private bool _DialogIsLoading = false;

        private bool _PageIsLoading = false;
        private PageResponse _PageSelected = null;

        private bool _TableIsLoading = false;
        private MudDataGrid<TableRowWrapper<PagePermissionResponse>> _Table;

        private HashSet<TableRowWrapper<PagePermissionResponse>> _TableItemSelected = new HashSet<TableRowWrapper<PagePermissionResponse>>();
        #endregion

        #region Method
        private async Task<IEnumerable<PageResponse>> ReqPage(List<FilterRequest> filters, SortRequest sort = null)
        {
            var result = new List<PageResponse>();
            try
            {
                sort ??= new SortRequest("sort", SortTypeEnum.ASC);

                var param = new ListRequest
                {
                    Start = 1,
                    Length = 11,
                    Filter = filters,
                    Sort = sort
                };

                var res = await _PageService.List(param, Token.BaseApiUrl, Token.RawToken);

                if (res.Succeeded)
                    result = res.List;
                else
                    _Snackbar.ShowError($"Error While Request :: {res.GetErrorMessage()}");
            }
            catch (Exception ex)
            {
                _Snackbar.ShowError($"Error at ReqPage :: {ex.Message}");
            }
            return result;
        }

        private async Task<IEnumerable<PageResponse>> SearchPage(string value)
        {
            var filters = new List<FilterRequest>
            {
                new FilterRequest("not_parent", "#")
            };

            if (!string.IsNullOrEmpty(value))
                filters.Add(new FilterRequest("name", value));

            return await ReqPage(filters, new SortRequest("section", SortTypeEnum.ASC));
        }

        private async Task GetPage(Guid id)
        {
            _PageIsLoading = true;
            StateHasChanged();

            var result = await ReqPage(new List<FilterRequest>
            {
                new FilterRequest("id", id.ToString())
            });
            _PageSelected = result.FirstOrDefault();

            _PageIsLoading = false;
            StateHasChanged();

            await _Table.ReloadServerData();
        }

        private void PageChanged(PageResponse value)
        {
            _PageSelected = value;
            StateHasChanged();

            _Table.ReloadServerData();
        }

        private async Task<GridData<TableRowWrapper<PagePermissionResponse>>> GetDataTable(GridState<TableRowWrapper<PagePermissionResponse>> state)
        {
            var result = new GridData<TableRowWrapper<PagePermissionResponse>>
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
                    Start = 1,
                    Length = 1000,
                    Filter = new List<FilterRequest>
                    {
                        new FilterRequest("idpage", (_PageSelected?.Id ?? Guid.Empty).ToString()),
                        new FilterRequest("active", "true")
                    },
                    Sort = new SortRequest("name", SortTypeEnum.ASC)
                };

                var res = await _PagePermissionService.List(param, Token.BaseApiUrl, Token.RawToken);

                if (res.Succeeded)
                {
                    result.Items = res.List.GenerateRowNumber(StaticMethod.GetStartRowNumber(1, res.List.Count)).ToList();
                    result.TotalItems = res.Count ?? 0;

                    if (DataEdit != null)
                        _TableItemSelected = result.Items.Where(_ => DataEdit.Permissions.Any(__ => __.Permission.Id == _.Data.Id)).ToHashSet();
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

            _DialogIsLoading = true;
            StateHasChanged();

            try
            {
                var dataReq = _TableItemSelected.Select(_ => new RolePermissionRequest
                {
                    IdRole = IdRole,
                    IdPermission = _.Data.Id
                }).ToList();

                StatusResponse res = null;
                if (DataEdit == null)
                    res = await _RolePermissionService.AddRange(dataReq, Token.BaseApiUrl, Token.RawToken);
                else
                    res = await _RolePermissionService.EditRange(dataReq, Token.BaseApiUrl, Token.RawToken);

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

            _DialogIsLoading = false;
            StateHasChanged();
        }
        #endregion
    }
}
