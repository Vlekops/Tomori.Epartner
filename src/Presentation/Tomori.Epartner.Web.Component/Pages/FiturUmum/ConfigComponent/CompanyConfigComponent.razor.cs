using MudBlazor;

namespace Tomori.Epartner.Web.Component.Pages.FiturUmum.ConfigComponent
{
    public partial class CompanyConfigComponent : ComponentBase
    {
        #region Override
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _ = GetData();
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
        private IConfigService _Service { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        #endregion

        #region Field
        private MudForm _Form;
        private bool _FormIsValid;
        private bool _FormIsLoading;

        private string _Name = string.Empty;
        private string _Mail = string.Empty;
        private string _Phone = string.Empty;
        private string _Address = string.Empty;
        private string _Description = string.Empty;
        private string _Website = string.Empty;
        #endregion

        #region Method
        private async Task GetData()
        {
            _FormIsLoading = true;
            StateHasChanged();

            try
            {
                var res = await _Service.GetCompany(Token.BaseApiUrl, Token.RawToken);
                if (res.Succeeded)
                {
                    _Name = res.Data.Name;
                    _Mail = res.Data.Mail;
                    _Phone = res.Data.Phone;
                    _Address = res.Data.Address;
                    _Description = res.Data.Description;
                    _Website = res.Data.Website;
                }
                else
                    _Snackbar.ShowError($"Error While Request :: {res.GetErrorMessage()}");
            }
            catch (Exception ex)
            {
                _Snackbar.ShowError($"Error at GetDataTable :: {ex.Message}");
            }

            _FormIsLoading = false;
            StateHasChanged();
        }
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
                var param = new CompanyConfig
                {
                    Mail = _Mail,
                    Address = _Address,
                    Description = _Description,
                    Name = _Name,
                    Phone = _Phone,
                    Website = _Website
                };

                StatusResponse res = await _Service.SaveCompany(param, Token.BaseApiUrl, Token.RawToken);

                if (res != null && res.Succeeded)
                    _Snackbar.ShowSuccess("Save Data Berhasil!");
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
