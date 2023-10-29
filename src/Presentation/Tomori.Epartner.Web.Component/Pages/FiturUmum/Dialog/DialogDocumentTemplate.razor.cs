using Blazored.TextEditor;
using Microsoft.AspNetCore.Components.Forms;
using System;
using HeyRed.Mime;
using System.Xml.Linq;

namespace Tomori.Epartner.Web.Component.Pages.FiturUmum.Dialog
{
    public partial class DialogDocumentTemplate : ComponentBase
    {
        #region Override
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (DataEdit != null)
                {
                    _Item = new FileModel(1, DataEdit.Code, DataEdit.Description, string.Empty, true, null);
                    _Item.Id = DataEdit.Id;
                    _Item.IsUploaded = true;

                    var _File = await GetBase64(DataEdit.Code);
                    if (_File.Succeeded)
                    {
                        _Item.Base64 = _File.Data.Base64;
                        _Item.Filename = _File.Data.Filename;
                        _Item.MimeType = _File.Data.MimeType;
                    }
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
        private IJSRuntime _Js { get; set; }
        [Inject]
        private IDocumentTemplateService _Service { get; set; }
        [Inject]
        private IDialogService _DialogService { get; set; }

        [CascadingParameter]
        private MudDialogInstance _MudDialog { get; set; }
        [Parameter]
        public TokenModel Token { get; set; }
        [Parameter]
        public DocumentTemplateResponse DataEdit { get; set; }
        #endregion

        #region Field
        private MudForm _Form;
        private bool _FormIsValid;
        private bool _FormIsLoading;

        private FileModel _Item = new FileModel(1, string.Empty, string.Empty, string.Empty, true, null);

        #endregion

        #region Method
        private async Task UploadFile(InputFileChangeEventArgs e)
        {
            try
            {
                var buffers = new byte[e.File.Size];
                var stream = await e.File.OpenReadStream(e.File.Size).ReadAsync(buffers);

                _Item.Base64 = Convert.ToBase64String(buffers);
                _Item.MimeType = MimeTypesMap.GetMimeType(Path.GetExtension(e.File.Name));
                _Item.IsUploaded = true;
                _Item.Filename = e.File.Name;
            }
            catch (Exception ex)
            {
                _Snackbar.ShowError($"Error at UploadFile :: {ex.Message}");
            }
            StateHasChanged();
        }
        private void DeleteFile()
        {
            _Item.Base64 = string.Empty;
            _Item.MimeType = string.Empty;
            _Item.IsUploaded = false;
            _Item.Filename = string.Empty;
            StateHasChanged();
        }
        private async Task DownloadFile()
        {
            if (_Item.IsUploaded)
                await _Js.DownloadFile(_Item.Filename, _Item.MimeType, _Item.Base64);
            else
                _Snackbar.ShowError($"File Not Uploaded!");
        }
        private async Task<ObjectResponse<FileObject>> GetBase64(string code)
        {
            ObjectResponse<FileObject> result = new ObjectResponse<FileObject>();
            try
            {
                result = await _Service.Get(code, Token.BaseApiUrl, Token.RawToken);
                if (!result.Succeeded)
                    _Snackbar.ShowError($"Error While Request :: {result.GetErrorMessage()}");
            }
            catch (Exception ex)
            {
                _Snackbar.ShowError($"Error at UploadFile :: {ex.Message}");
            }
            return result;
        }

        public async Task Save()
        {
            await _Form.Validate();

            if (!_Item.IsUploaded)
            {
                _Snackbar.ShowWarning("File Belum di Upload!");
                return;
            }

            var confirm = await _DialogService.ShowMessageBox("Konfirmasi", "Apakah Anda Yakin?", yesText: "Ya", noText: "Tidak", options: new DialogOptions { MaxWidth = MaxWidth.ExtraSmall });
            if (confirm == null || !confirm.Value)
                return;

            _FormIsLoading = true;
            StateHasChanged();

            try
            {
                var param = new DocumentTemplateRequest
                {
                    Code = _Item.Kode,
                    Description = _Item.Title,
                    File = new FileObject()
                    {
                        Base64 = _Item.Base64,
                        Filename = _Item.Filename,
                        MimeType = _Item.MimeType
                    }
                };

                StatusResponse res = await _Service.Upload(param, Token.BaseApiUrl, Token.RawToken);

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
