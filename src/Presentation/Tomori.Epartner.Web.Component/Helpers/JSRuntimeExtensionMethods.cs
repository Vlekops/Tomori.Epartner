namespace Tomori.Epartner.Web.Component.Helpers
{
    public static class JSRuntimeExtensionMethods
    {
        public static async ValueTask DotNetInit<T>(this IJSRuntime js, DotNetObjectReference<T> dotNetObjectReference) where T : class
        {
            try
            {
                await js.InvokeVoidAsync("DotNetInit", dotNetObjectReference);
            }
            catch
            {
            }
        }

        public static async ValueTask ShowBodyLoading(this IJSRuntime js, bool value)
        {
            try
            {
                await js.InvokeVoidAsync("ShowBodyLoading", value);
            }
            catch
            {
            }
        }

        public static async ValueTask DownloadFile(this IJSRuntime js, string filename, string mimeType, string base64String)
        {
            try
            {
                await js.InvokeVoidAsync("Base64ToFile", filename, mimeType, base64String);
            }
            catch
            {
            }
        }

        public static async ValueTask PreviewFile(this IJSRuntime js, string filename, string mimeType, string base64String)
        {
            try
            {
                await js.InvokeVoidAsync("PreviewFile", filename, mimeType, base64String);
            }
            catch
            {
            }
        }
    }
}
