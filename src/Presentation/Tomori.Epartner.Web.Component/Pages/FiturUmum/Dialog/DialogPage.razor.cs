namespace Tomori.Epartner.Web.Component.Pages.FiturUmum.Dialog
{
    public partial class DialogPage : ComponentBase
    {
        #region Override
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (DataEdit != null)
                {
                    if (DataEdit.IdParent.HasValue)
                        _ = GetPageParent(DataEdit.IdParent.Value);

                    _Section = DataEdit.Section;
                    _Code = DataEdit.Code;
                    _Name = DataEdit.Name;
                    _Description = DataEdit.Description;
                    _Navigation = DataEdit.Navigation;
                    _Icon = DataEdit.Icon;
                    _Sort = DataEdit.Sort;
                    _Active = DataEdit.Active;

                    StateHasChanged();
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
        [CascadingParameter]
        private MudDialogInstance _MudDialog { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        [Parameter]
        public PageResponse DataEdit { get; set; }
        #endregion

        #region Field
        private MudForm _Form;
        private bool _FormIsValid;
        private bool _FormIsLoading;

        private PageResponse _PageParentSelected = null;
        private bool _PageParentIsLoading = false;

        private MudTextField<string> _SectionElement;
        private string _Section = string.Empty;
        private string _Code = string.Empty;
        private string _Name = string.Empty;
        private string _Description = string.Empty;
        private string _Navigation = string.Empty;
        private string _Icon = string.Empty;
        private int? _Sort;
        private bool _Active = true;
        #endregion

        #region Method
        #region Req Page
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

        private async Task<IEnumerable<PageResponse>> SearchParentPage(string value)
        {
            var filters = new List<FilterRequest>
            {
                new FilterRequest("navigation", "#")
            };

            if (!string.IsNullOrEmpty(value))
                filters.Add(new FilterRequest("name", value));

            return await ReqPage(filters, new SortRequest("section", SortTypeEnum.ASC));
        }

        private async Task GetPageParent(Guid id)
        {
            _PageParentIsLoading = true;
            StateHasChanged();

            var result = await ReqPage(new List<FilterRequest>
            {
                new FilterRequest("id", id.ToString())
            });
            _PageParentSelected = result.FirstOrDefault();

            _PageParentIsLoading = false;
            StateHasChanged();
        }

        private void PageParentChanged(PageResponse value)
        {
            _PageParentSelected = value;
            _Section = value?.Section ?? string.Empty;
            StateHasChanged();

            if (!string.IsNullOrEmpty(_Section) && _SectionElement != null)
                _SectionElement.ResetValidation();
        }
        #endregion

        private async Task Save()
        {
            await _Form.Validate();

            if (!_FormIsValid)
            {
                _Snackbar.ShowWarning("Ada Beberapa Field Yang Belum Terisi!");
                return;
            }

            var confirm = await _DialogService.ShowMessageBox("Konfirmasi", "Apakah Anda Yakin?", yesText: "Ya", noText: "Tidak", options: new DialogOptions { MaxWidth = MaxWidth.ExtraSmall });
            if (confirm == null || !confirm.Value)
                return;

            _FormIsLoading = true;
            StateHasChanged();

            try
            {
                var param = new PageRequest
                {
                    IdParent = _PageParentSelected?.Id ?? null,
                    Section = _Section,
                    Code = _Code,
                    Name = _Name,
                    Navigation = _Navigation,
                    Icon = _Icon,
                    Sort = _Sort ?? 0,
                    Description = _Description,
                    Active = _Active
                };

                StatusResponse res = null;
                if (DataEdit == null)
                    res = await _PageService.Add(param, Token.BaseApiUrl, Token.RawToken);
                else
                    res = await _PageService.Edit(DataEdit.Id, param, Token.BaseApiUrl, Token.RawToken);

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

            _FormIsLoading = false;
            StateHasChanged();
        }
        #endregion
    }
}
