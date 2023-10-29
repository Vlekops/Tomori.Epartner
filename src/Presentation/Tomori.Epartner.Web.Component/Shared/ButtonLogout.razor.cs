using Blazored.LocalStorage;
using System.Reflection.Metadata;

namespace Tomori.Epartner.Web.Component.Shared
{
    public partial class ButtonLogout : ComponentBase
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
        public IDialogService _DialogService { get; set; }
        [Inject]
        private ILocalStorageService _LocalStorage { get; set; }
        [Inject]
        private NavigationManager _NavManager { get; set; }
        #endregion

        #region Field

        #endregion

        #region Method

        private async Task DoLogout()
        {
            var confirm = await _DialogService.ShowMessageBox("Konfirmasi", "Apakah Anda Yakin akan keluar dari applikasi?", yesText: "Ya", noText: "Tidak", options: new DialogOptions { MaxWidth = MaxWidth.ExtraSmall });
            if (confirm == null || !confirm.Value)
                return;
            await _LocalStorage.ClearAsync();
            _NavManager.NavigateTo("/Account/Logoff", true);
        }
        #endregion
    }
}
