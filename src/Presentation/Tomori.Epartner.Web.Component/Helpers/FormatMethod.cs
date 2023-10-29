using System.Globalization;

namespace Tomori.Epartner.Web.Component.Helpers
{
    public static class FormatMethod
    {
        public static string ToCurrencyFormat(this decimal value, bool withScale = false)
        {
            withScale = Math.Abs(value % 1) != 0.00M;
            string format = withScale ? "{0:N}" : "{0:N0}";
            return string.Format(CultureInfo.CreateSpecificCulture("en-us"), format, value);
        }

        public static string ToCurrencyFormat(this double value, bool withScale = false)
        {
            withScale = Math.Abs(value % 1) != 0.00D;
            string format = withScale ? "{0:N}" : "{0:N0}";
            return string.Format(CultureInfo.CreateSpecificCulture("en-us"), format, value);
        }

        public static string ToCurrencyFormat(this int value, bool withScale = false)
        {
            string format = withScale ? "{0:N}" : "{0:N0}";
            return string.Format(CultureInfo.CreateSpecificCulture("en-us"), format, value);
        }

        public static string ToCurrencyFormat(this long value, bool withScale = false)
        {
            string format = withScale ? "{0:N}" : "{0:N0}";
            return string.Format(CultureInfo.CreateSpecificCulture("en-us"), format, value);
        }

        public static string ToIDRFormat(this decimal value, bool withScale = false)
        {
            string format = withScale ? "{0:N}" : "{0:N0}";
            return string.Format(CultureInfo.GetCultureInfo("id-ID"), format, value).Replace(",", ".");
        }

        public static string RemoveFirst(this string value, string removeValue)
        {
            if (value.StartsWith(removeValue))
                value = value.Substring(removeValue.Length, value.Length - removeValue.Length);
            return value;
        }

        public static string DateTimeToIdFormat(this DateTime value, string format)
        {
            return value.ToString(format, CultureInfo.GetCultureInfo("id-ID"));
        }
    }

    public static class RowNumberWrapper
    {
        public static IEnumerable<TableRowWrapper<T>> GenerateRowNumber<T>(this IEnumerable<T> data, int start = 1)
        {
            foreach (var item in data)
            {
                yield return new TableRowWrapper<T>(start++, item);
            }
        }
    }

    public static class SnackbarHelper
    {
        public static void Show(this ISnackbar snackbar, string message, Action<SnackbarOptions> configure = null)
        {
            snackbar.Show(message, Severity.Normal, configure);
        }

        public static void ShowSuccess(this ISnackbar snackbar, string message, Action<SnackbarOptions> configure = null)
        {
            snackbar.Show(message, Severity.Success, configure);
        }

        public static void ShowInfo(this ISnackbar snackbar, string message, Action<SnackbarOptions> configure = null)
        {
            snackbar.Show(message, Severity.Info, configure);
        }

        public static void ShowWarning(this ISnackbar snackbar, string message, Action<SnackbarOptions> configure = null)
        {
            snackbar.Show(message, Severity.Warning, configure);
        }

        public static void ShowError(this ISnackbar snackbar, string message, Action<SnackbarOptions> configure = null)
        {
            snackbar.Show(message, Severity.Error, configure);
        }

        private static void Show(this ISnackbar snackbar, string message, Severity severity, Action<SnackbarOptions> configure = null)
        {
            snackbar.Clear();
            snackbar.Add(message, severity, configure);
        }
    }

    public static class DialogHelper
    {
        public static async Task<bool> Confirm(this IDialogService dialogService, string title = "Konfirmasi", string message = "Apakah Anda Yakin?")
        {
            var html = new MarkupString($@"
                <div class=""d-flex flex-md-row flex-column gap-4 align-center"">
                    <div class=""d-flex justify-center"">
                        <svg class=""mud-icon-root mud-svg-icon"" viewBox=""0 0 24 24"" style=""font-size: 4rem;background: #E2FFE7;border-radius: 50%;padding: 10px;color: #02841B;"">
                            {IconsExtension.CheckDoubleLine}
                        </svg>
                    </div>
                    <div>
                        <p class=""fw-bold mb-1"">{title}</p>
                        <p class=""mb-0"">{message}</p>
                    </div>
                </div>
            ");

            var confirm = await dialogService.ShowMessageBox("", html, yesText: "Ya", noText: "Tidak", options: DialogWidth.XS);
            if (confirm == null || !confirm.Value)
                return false;
            return true;
        }
    }
}
