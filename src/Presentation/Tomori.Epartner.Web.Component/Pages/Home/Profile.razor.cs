using Microsoft.JSInterop;
using Tomori.Epartner.Web.Component.Services;

namespace Tomori.Epartner.Web.Component.Pages.Home
{
    public partial class Profile : ComponentBase
    {
        #region Override
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await _JsRuntime.InvokeVoidAsync("DotNetInitProfile", DotNetObjectReference.Create(this));
                await _JsRuntime.InvokeVoidAsync("ScrollLoader");
                _ = GetDataUser();
                _ = GetActivity();
            }

            await base.OnAfterRenderAsync(firstRender);
        }
        #endregion

        #region Inject, Cascading, Parameter
        [Inject]
        private ISnackbar _Snackbar { get; set; }
        [Inject]
        private IUserService _UserService { get; set; }
        [Inject]
        private IJSRuntime _JsRuntime { get; set; }
        [Inject]
        private ILogService _LogService { get; set; }
        [JSInvokable]
        public void ReceiveDataPagination(int page)
        {
            _ = GetActivity(page);
        }
        [Parameter]
        public TokenModel Token { get; set; }

        #region Profile
        private string _Search = string.Empty;
        private MudForm _Form;
        private bool _FormIsValid;
        private bool _FormIsLoading;
        private string Fullname;
        private string Mail;
        private string PhoneNumber;
        #endregion


        #region Activity
        private bool _ActivityLoading = false;
        private List<ActivityListGrouped> _ActivityListGrouped = new();
        private int _CurrentPage = 5;

        #endregion

        #endregion

        #region Method
        public async Task GetDataUser()
        {
            try
            {
				_FormIsLoading = true;
				StateHasChanged();

				var result = await _UserService.Get(Token.User.Id, Token.BaseApiUrl, Token.RawToken);
                if (result.Succeeded)
                {
					Fullname = result.Data.Fullname;
					Mail = result.Data.Mail;
					PhoneNumber = result.Data.PhoneNumber;
				}
			}
            catch (Exception ex)
            {
				_Snackbar.ShowError($"Error at GetDataTable :: {ex.Message}");
			}

			_FormIsLoading = false;
			StateHasChanged();
		}

        public async Task GetActivity(int page = 0)
        {
            try
            {
                _ActivityLoading = true;
                StateHasChanged();
                var list_filter = new List<FilterRequest>();
                var filter = new FilterRequest();
                list_filter.Add(filter);
                var request = new ListRequest()
                {
                    Sort = new SortRequest("sort", SortTypeEnum.DESC),
                    Length = _CurrentPage + page,
                    Filter = list_filter,
                    Start = page == 0 ? 1 : page
                };


                var result = await _LogService.ActivityListGrouped(request, Token.BaseApiUrl, Token.RawToken);
                if (result.Succeeded)
                {
                    _ActivityListGrouped = result.List;
                    _ActivityLoading = false;
                    _CurrentPage += 5;

                    StateHasChanged();
                }
            }
            catch (Exception ex)
            {
                _Snackbar.ShowError($"Error at Get Data Activity :: {ex.Message}");
            }
        }

        #endregion
    }
}
