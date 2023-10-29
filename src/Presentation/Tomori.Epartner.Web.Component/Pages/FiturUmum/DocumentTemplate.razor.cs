using Tomori.Epartner.Web.Component.Pages.FiturUmum.Dialog;
using Tomori.Epartner.Web.Component.Pages.Report.Dialog;

namespace Tomori.Epartner.Web.Component.Pages.FiturUmum
{
    public partial class DocumentTemplate : ComponentBase
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
        private IJSRuntime _Js { get; set; }
        [Inject]
        public IDialogService _DialogService { get; set; }
        [Inject]
        private IDocumentTemplateService _Service { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        [Parameter]
        public List<string> Permission { get; set; }
        #endregion

        #region Field
        private string _Search = string.Empty;

        private bool _TableIsLoading = false;
        private MudDataGrid<TableRowWrapper<DocumentTemplateResponse>> _Table = new();
        #endregion

        #region Method
        private async Task<GridData<TableRowWrapper<DocumentTemplateResponse>>> GetDataTable(GridState<TableRowWrapper<DocumentTemplateResponse>> state)
        {
            var result = new GridData<TableRowWrapper<DocumentTemplateResponse>>
            {
                Items = new List<TableRowWrapper<DocumentTemplateResponse>>(),
                TotalItems = 0
            };
            
            _TableIsLoading = true;
            StateHasChanged();

            try
            {
                int start = state.Page + 1;
                int length = state.PageSize;

                var res = await _Service.List(_Search,start,length,Token.BaseApiUrl, Token.RawToken);

                if (res.Succeeded)
                {
                    result.Items = res.List.GenerateRowNumber(StaticMethod.GetStartRowNumber(start, length)).ToList();
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

        private async Task AddData()
        {
            var paramDialog = new DialogParameters
            {
                { "Token", Token }
            };

            var dialog = _DialogService.Show<DialogDocumentTemplate>("Tambah Data Document", paramDialog, new DialogOptions { MaxWidth = MaxWidth.Medium });
            var dialogResult = await dialog.Result;
            if (!dialogResult.Canceled)
            {
                _Snackbar.ShowSuccess("Add Data Berhasil!");
                _ = _Table.ReloadServerData();
            }
        }

        private async Task Edit(DocumentTemplateResponse model)
        {
            var paramDialog = new DialogParameters
            {
                { "Token", Token },
                { "DataEdit", model }
            };

            var dialog = _DialogService.Show<DialogDocumentTemplate>("Ubah Data Page", paramDialog, new DialogOptions { MaxWidth = MaxWidth.Medium });
            var dialogResult = await dialog.Result;
            if (!dialogResult.Canceled)
            {
                _Snackbar.ShowSuccess("Ubah Data Berhasil!");
                _ = _Table.ReloadServerData();
            }
        }

        private async Task Delete(DocumentTemplateResponse model)
        {
            var confirm = await _DialogService.ShowMessageBox("Konfirmasi", "Apakah Anda Yakin?", yesText: "Ya", noText: "Tidak", options: new DialogOptions { MaxWidth = MaxWidth.ExtraSmall });
            if (confirm == null || !confirm.Value)
                return;

            _TableIsLoading = true;
            StateHasChanged();

            try
            {
                var res = await _Service.Delete(model.Id, Token.BaseApiUrl, Token.RawToken);

                if (res.Succeeded)
                {
                    _Snackbar.ShowSuccess("Hapus Data Berhasil!");
                    _ = _Table.ReloadServerData();
                }
            }
            catch (Exception ex)
            {
                _Snackbar.ShowError($"Error at GetPage {ex.Message}");
            }

            _TableIsLoading = false;
            StateHasChanged();

        }

        private async Task Download(DocumentTemplateResponse model)
        {
            try
            {
                var res = await _Service.Get(model.Code,Token.BaseApiUrl, Token.RawToken);
                if (res.Succeeded)
                {
                    await _Js.DownloadFile(res.Data.Filename, res.Data.MimeType, res.Data.Base64);
                }
                else
                    _Snackbar.ShowError($"Error While Request :: {res.GetErrorMessage()}");
            }
            catch (Exception ex)
            {
                _Snackbar.ShowError($"Error at DeleteData :: {ex.Message}");
            }
        }
        #endregion
    }
}
