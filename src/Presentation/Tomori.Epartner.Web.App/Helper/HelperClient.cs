using Newtonsoft.Json;
using NuGet.Common;
using Tomori.Epartner.Web.Component.Services;

namespace Tomori.Epartner.Web.App.Helper
{
    public class HelperClient
    {
        public const string AUTHENTICATION_SCHEMA = "Tomori.Epartner";
        public const string PAGE_COOKIE = "Tomori.Epartner.Page";

        public static (bool Success, List<PageResponse> Result) GetPage(HttpRequest request)
        {
            try
            {
                var page_cookie = request.Cookies[PAGE_COOKIE];
                if (page_cookie != null)
                {
                    var base64EncodedBytes = Convert.FromBase64String(page_cookie);
                    string jsonText = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
                    var data = JsonConvert.DeserializeObject<List<PageResponse>>(jsonText)!;
                    return (true, data);
                }
                else
                    return (false, null);
            }
            catch
            {
                return (false, null);
            }
        }
        public static (CookieOptions option, string result) SetPage(List<PageResponse> Page,DateTime expired)
        {
            string raw = JsonConvert.SerializeObject(Page);
            var raw_bytes = System.Text.Encoding.UTF8.GetBytes(raw);

            CookieOptions optionMyCookie = new()
            {
                Expires = expired.ToLocalTime()
            };
            return (optionMyCookie, Convert.ToBase64String(raw_bytes));
        }

        public static List<Models.MenuWrapperModel> SetMenu(List<PageResponse> DataMenu)
        {
            List<Models.MenuWrapperModel> result = new List<Models.MenuWrapperModel>();
            if (DataMenu != null && DataMenu.Any())
            {
                var sections = DataMenu.Select(_ => _.Section).Distinct().ToList();

                var menu = new List<Models.MenuWrapperModel>();
                foreach (var item in sections)
                {
                    var section = new Models.MenuWrapperModel
                    {
                        Section = item
                    };

                    var objs = DataMenu.Where(_ => _.Section == item).ToList();

                    if (objs.Any())
                        section.Menus = SetMenuItem(objs);

                    menu.Add(section);
                }
                result = menu;
            }
            return result;
        }

        private static List<Models.MenuItemModel> SetMenuItem(List<PageResponse> pages)
        {
            var result = new List<Models.MenuItemModel>();
            foreach (var page in pages)
            {
                var obj = new Models.MenuItemModel
                {
                    Id = page.Id,
                    Code = page.Code,
                    Name = page.Name,
                    Description = page.Description,
                    Icon = page.Icon,
                    Sort = page.Sort,
                    Navigation = page.Navigation
                };

                if (page.Childs.Any())
                    obj.Items = SetMenuItem(page.Childs);

                result.Add(obj);
            }
            return result;
        }
    }

}
