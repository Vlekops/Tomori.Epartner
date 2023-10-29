namespace Tomori.Epartner.Web.Component.Pages.Home
{
    public partial class FAQ : ComponentBase
    {
        #region Override
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await GetListCategory();
            }

            await base.OnAfterRenderAsync(firstRender);
        }
        #endregion

        #region Inject, Cascading, Parameter
        [Inject]
        private ISnackbar _Snackbar { get; set; }
        [Inject]
        private IFaqService _FaqService { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }

        private List<FaqResponse> _ListFaq = new();
        private string _Search = string.Empty;
        #endregion

        #region Method

        private async Task GetListCategory()
        {
            var result = new List<string>();
            try
            {

                var list_filter = new List<FilterRequest>();
                var filter = new FilterRequest()
                {
                    Field = "question",
                    Search = _Search
                };
                list_filter.Add(filter);
                var param = new ListRequest()
                {
					Sort = new SortRequest("sort", SortTypeEnum.ASC),
					Length = 0,
                    Filter = list_filter,
                    Start = 0
                };


                var res = await _FaqService.GetDataFaq(param, Token.BaseApiUrl, Token.RawToken);
                if (res.Succeeded)
                {
                    _ListFaq = res.List;
					StateHasChanged();
				}

            }
            catch (Exception ex)
            {
                _Snackbar.ShowError($"Error at GetDataTable :: {ex.Message}");
            }
        }


        #endregion
    }
}
