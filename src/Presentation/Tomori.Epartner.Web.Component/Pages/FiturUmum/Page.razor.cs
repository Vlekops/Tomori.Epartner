using Tomori.Epartner.Web.Component.Pages.FiturUmum.Dialog;

namespace Tomori.Epartner.Web.Component.Pages.FiturUmum
{
    public class PageViewWrapperModel
    {
        public string Section { get; set; }
        public HashSet<PageViewModel> Items { get; set; } = new HashSet<PageViewModel>();
    }

	public class PageViewModel : PageResponse
	{
        public bool IsExpanded { get; set; } = false;
        public bool IsLoading { get; set; } = false;
        public bool IsDummy { get; set; } = false;
        public HashSet<PageViewModel> Items { get; set; } = new HashSet<PageViewModel>();
	}

    public partial class Page : ComponentBase
    {
        #region Override
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
				_ = GetPageWrapper();
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
        private IPageService _PageService { get; set; }
		[Parameter]
		public TokenModel Token { get; set; }
        [Parameter]
        public List<string> Permission { get; set; }
        #endregion

        #region Field
        private bool _TreeIsLoading = false;
        private List<PageViewWrapperModel> _WrapperItems = new List<PageViewWrapperModel>();
		#endregion

		#region Method
        private async Task DoExpand(bool value, PageViewModel model)
        {
            if (!value)
            {
                model.IsExpanded = value;
                StateHasChanged();
            }

            if (value)
            {
                model.IsLoading = true;
                StateHasChanged();
                await Task.Delay(3000);

                model.Items = await GetPage(model.Id);

                model.IsLoading = false;
                model.IsExpanded = value;
                StateHasChanged();
            }
        }

		private async Task GetPageWrapper()
		{
            _TreeIsLoading = true;
            StateHasChanged();

            await GetPage(Guid.Empty);
            
            _TreeIsLoading = false;
            StateHasChanged();
        }

        private async Task<HashSet<PageViewModel>> GetPage(Guid idParent)
		{
			var result = new HashSet<PageViewModel>();
			try
			{
                var param = new ListRequest
                {
                    Start = 0,
                    Length = 0,
                    Filter = new List<FilterRequest>
					{
						new FilterRequest("idparent", idParent == Guid.Empty ? "null" : idParent.ToString())
					},
                    Sort = new SortRequest("sort", SortTypeEnum.ASC)
                };
                
                var res = await _PageService.List(param, Token.BaseApiUrl, Token.RawToken);
                if (res.Succeeded)
                {
                    result = res.List.Select(_ => new PageViewModel
                    {
                        Id = _.Id,
                        IdParent = _.IdParent,
                        Section = _.Section,
                        Code = _.Code,
                        Name = _.Name,
                        Description = _.Description,
                        Navigation = _.Navigation,
                        Icon = _.Icon,
                        Sort = _.Sort,
                        Active = _.Active
                    }).ToHashSet();

                    // tambah dummy untuk memunculkan expand button
                    foreach (var item in result.Where(_ => _.Navigation == "#"))
                    {
                        item.Items.Add(new PageViewModel
                        {
                            IsDummy = true,
                            Id = Guid.NewGuid(),
                            IdParent = item.Id,
                            Name = "-"
                        });
                    }

                    if (idParent == Guid.Empty)
                    {
                        _WrapperItems.Clear();

                        var sections = res.List.Select(_ => _.Section).Distinct().ToList();
                        _WrapperItems = sections.Select(_ => new PageViewWrapperModel
                        {
                            Section = _,
                            Items = result.Where(__ => __.Section == _).ToHashSet()
                        }).ToList();

                        StateHasChanged();
                    }
                }
				else
                    _Snackbar.ShowError($"Error While Request :: {res.GetErrorMessage()}");
            }
			catch (Exception ex)
			{
				_Snackbar.ShowError($"Error at GetPage {ex.Message}");
			}
			return result;
        }

		private async Task AddData()
		{
            var paramDialog = new DialogParameters
            {
                { "Token", Token }
            };

            var dialog = _DialogService.Show<DialogPage>("Tambah Data Page", paramDialog, new DialogOptions { MaxWidth = MaxWidth.Small });
            var dialogResult = await dialog.Result;
            if (!dialogResult.Canceled)
            {
                _Snackbar.ShowSuccess("Add Data Berhasil!");
                _ = GetPageWrapper();
            }
        }

        private async Task EditData(PageViewModel model)
        {
            var obj = new PageResponse
            {
                Id = model.Id,
                IdParent = model.IdParent,
                Section = model.Section,
                Code = model.Code,
                Name = model.Name,
                Navigation = model.Navigation,
                Icon = model.Icon,
                Sort = model.Sort,
                Description = model.Description,
                Active = model.Active
            };

            var paramDialog = new DialogParameters
            {
                { "Token", Token },
                { "DataEdit", obj }
            };

            var dialog = _DialogService.Show<DialogPage>("Ubah Data Page", paramDialog, new DialogOptions { MaxWidth = MaxWidth.Small });
            var dialogResult = await dialog.Result;
            if (!dialogResult.Canceled)
            {
                _Snackbar.ShowSuccess("Ubah Data Berhasil!");
                _ = GetPageWrapper();
            }
        }

        private async Task DeleteData(PageViewModel model)
        {
            var confirm = await _DialogService.ShowMessageBox("Konfirmasi", "Apakah Anda Yakin?", yesText: "Ya", noText: "Tidak", options: new DialogOptions { MaxWidth = MaxWidth.ExtraSmall });
            if (confirm == null || !confirm.Value)
                return;

            model.IsLoading = true;
            StateHasChanged();

            try
            {
                var res = await _PageService.Delete(model.Id, Token.BaseApiUrl, Token.RawToken);

                if (res.Succeeded)
                {
                    _Snackbar.ShowSuccess("Hapus Data Berhasil!");
                    _ = GetPageWrapper();
                }
            }
            catch (Exception ex)
            {
                _Snackbar.ShowError($"Error at GetPage {ex.Message}");
            }

            model.IsLoading = false;
            StateHasChanged();

        }

        private void AddPermission(PageViewModel model)
        {
            var paramDialog = new DialogParameters
            {
                { "Token", Token },
                { "IdPage", model.Id }
            };

            _DialogService.Show<DialogPagePermission>($"Permission Page - {model.Name}", paramDialog, new DialogOptions { MaxWidth = MaxWidth.Small });
        }
        #endregion
    }
}
