﻿namespace Tomori.Epartner.Web.Component.Pages.Home.TaskToDo
{
    public partial class HistoryTask : ComponentBase
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
        private IWorkflowService _Service { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        #endregion

        #region Field
        private int _TotalData = 0;
        private string _FilterSearch;

        private bool _TableIsLoading = false;
        private MudDataGrid<TableRowWrapper<WorkflowHistoryResponse>> _Table;
        #endregion

        #region Method
        private void FilterSearchKeyPress(KeyboardEventArgs args)
        {
            if (args != null && args.Key != null && args.Key.Equals("Enter"))
                _Table.ReloadServerData();
        }

        private async Task<GridData<TableRowWrapper<WorkflowHistoryResponse>>> ListData(GridState<TableRowWrapper<WorkflowHistoryResponse>> state)
        {
            var result = new GridData<TableRowWrapper<WorkflowHistoryResponse>>
            {
                Items = new List<TableRowWrapper<WorkflowHistoryResponse>>(),
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
                        new FilterRequest("additional_filter", "join_workflow"),
                        new FilterRequest("iduser", Token.User.Id.ToString()),
                        new FilterRequest("idworkflowstatusother", "-")
                    },
                    Sort = new SortRequest("CreateDate", SortTypeEnum.DESC)
                };

                if (state.SortDefinitions.Any())
                {
                    var obj = state.SortDefinitions.FirstOrDefault();
                    param.Sort = new SortRequest(obj.SortBy.Replace("Data.", ""), obj.Descending ? SortTypeEnum.DESC : SortTypeEnum.ASC);
                }

                if (!string.IsNullOrEmpty(_FilterSearch))
                    param.Filter.Add(new FilterRequest("search", _FilterSearch));

                var res = await _Service.HistoryOther(param, Token.BaseApiUrl, Token.RawToken);

                if (res.Succeeded)
                {
                    result.Items = res.List.GenerateRowNumber(StaticMethod.GetStartRowNumber(param.Start.Value, param.Length.Value)).ToList();
                    result.TotalItems = res.Count ?? 0;
                    _TotalData = res.Count ?? 0;
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
