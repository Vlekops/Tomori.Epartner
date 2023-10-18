namespace Tomori.Epartner.Web.Component.Pages.Home
{
    public partial class Notification : ComponentBase
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
        private INotificationService _Service { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        #endregion

        #region Field
        private bool _TableIsLoading = false;
        private MudTable<TableRowWrapper<NotificationResponse>> _Table;
        #endregion

        #region Method
        private async Task<TableData<TableRowWrapper<NotificationResponse>>> ListData(TableState state)
        {
            var result = new TableData<TableRowWrapper<NotificationResponse>>
            {
                Items = new List<TableRowWrapper<NotificationResponse>>(),
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
                    Filter = new List<FilterRequest>()
                    {
                        new FilterRequest()
                        {
                            Field = "iduser",
                            Search = Token.User.Id.ToString()
                        }
                    },
                    Sort = new SortRequest("createdate", SortTypeEnum.DESC)
                };
                var res = await _Service.List(param, Token.BaseApiUrl, Token.RawToken);

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

        #endregion
    }
}
