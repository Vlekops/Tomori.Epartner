using Tomori.Epartner.Web.Component.Pages.FiturUmum.Dialog;

namespace Tomori.Epartner.Web.Component.Pages.FiturUmum.AuditList
{
    public partial class AddActivity : ComponentBase
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
        private ILogService _LogService { get; set; }
        [Inject]
        private IUserService _UserService { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        #endregion

        #region field
        private MudDataGrid<TableRowWrapper<AddActivityLogResponse>> _Table;
        private bool _TableIsLoading = false;
        private List<string> _User = new();
        private string _selectedUser = string.Empty;
        private string _Search = string.Empty;
        private MudAutocomplete<UserResponse> _UserElement;
        private UserResponse _UserSelected = null;
        DateTime _picker = DateTime.Today;
        #endregion

        #region Method
        private async Task<GridData<TableRowWrapper<AddActivityLogResponse>>> GetDataTable(GridState<TableRowWrapper<AddActivityLogResponse>> state)
        {
            var result = new GridData<TableRowWrapper<AddActivityLogResponse>>
            {
                Items = new List<TableRowWrapper<AddActivityLogResponse>>(),
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
                    Filter = new List<FilterRequest>(),
                    Sort = new SortRequest("createdate", SortTypeEnum.DESC)
                };

                if (_UserSelected != null)
                {
                    param.Filter.Add(new FilterRequest()
                    {
                        Field = "iduser",
                        Search = _UserSelected.Id.ToString()
                    });
                }

                if (state.SortDefinitions.Any())
                {
                    var obj = state.SortDefinitions.FirstOrDefault();
                    param.Sort = new SortRequest(obj.SortBy, obj.Descending ? SortTypeEnum.DESC : SortTypeEnum.ASC);
                }

                foreach (var item in state.FilterDefinitions)
                {
                    param.Filter.Add(new FilterRequest(item.Column.PropertyName, item.Value?.ToString() ?? ""));
                }

                var res = await _LogService.AddActivity("Activity", Token.BaseApiUrl, Token.RawToken);

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

        private async Task FilterByUser(UserResponse userResponse)
        {
            _UserSelected = userResponse;
            await _Table.ReloadServerData();
        }
        #endregion
    }
}
