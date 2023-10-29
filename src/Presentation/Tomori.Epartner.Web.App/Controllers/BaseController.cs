using Tomori.Epartner.Web.App.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Tomori.Epartner.Web.Component.Helpers;
using Tomori.Epartner.Web.Component.Services;
using System.Security.Policy;

namespace Tomori.Epartner.Web.App.Controllers
{

    [SessionAuthorize]
    public class BaseController<T> : Controller
    {
        private ILogger<T> _loggerInstance;
        private ITokenHelper _tokenInstance;
        private ILogService _logServiceInstance;
        private IPageService _pageServiceInstance;
        private IUserService _userServiceInstance;
        private INotificationService _notificationServiceInstance;

        protected ILogger<T> _logger => _loggerInstance ??= HttpContext.RequestServices.GetService<ILogger<T>>();
        protected ITokenHelper _token => _tokenInstance ??= HttpContext.RequestServices.GetService<ITokenHelper>();
        protected ILogService _logService => _logServiceInstance ??= HttpContext.RequestServices.GetService<ILogService>();
        protected IPageService _pageService => _pageServiceInstance ??= HttpContext.RequestServices.GetService<IPageService>();
        protected IUserService _userService => _userServiceInstance ??= HttpContext.RequestServices.GetService<IUserService>();
        protected INotificationService _notificationService => _notificationServiceInstance ??= HttpContext.RequestServices.GetService<INotificationService>();
        protected TokenModel _tokenData;
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var decode_token = _token.DecodeToken(HttpContext);
            if (!decode_token.Success)
            {
                context.Result = new RedirectResult($"~/Account/Login?redirect={Request.Path}");
                return;
            }
            List<string> exclude_path = new List<string>()
            {
                "/home/notificationclick",
                "/home/notification",
                "/home/refreshtoken",
                "/home/dashboard",
                "/home/faq",
                "/home/dashboard",
                "/home/dokumentasi",
                "/home/bantuan",
                "/home/profile",
            };
            var menu = HelperClient.GetPage(Request);
            if (!menu.Success)
            {
                var page = await _pageService.GetByUser(decode_token.Token.BaseApiUrl, decode_token.Token.RawToken);
                if (page.Succeeded)
                {
                    menu = (true, page.List);
                    var page_cookies = HelperClient.SetPage(page.List, decode_token.Token.ExpiredAt);
                    Response.Cookies.Append(HelperClient.PAGE_COOKIE, page_cookies.result);
                }
            }


            _tokenData = decode_token.Token;
            ViewBag.Token = decode_token.Token;
            var permission = Permission(Request.RouteValues, menu.Result);
            if (!permission.Success && !exclude_path.Contains(Request.Path.ToString().Trim().ToLower()))
            {
                context.Result = RedirectToAction("Index", "Forbidden", new { Area = "" }); ;
                return;
            }
            await base.OnActionExecutionAsync(context, next);
            var photo = await _userService.GetPhoto(decode_token.Token.User.Id, decode_token.Token.BaseApiUrl, decode_token.Token.RawToken);
            if (photo.Succeeded)
                ViewBag.Photo = photo.Data;

            var notif = await _notificationService.List(new ListRequest
            {
                Start = 1,
                Length = 5,
                Filter = new List<FilterRequest>
                {
                    new FilterRequest("isopen", "false"),
                    new FilterRequest("iduser", decode_token.Token.User.Id.ToString())
                },
                Sort = new SortRequest("createdate", SortTypeEnum.DESC)
            }, decode_token.Token.BaseApiUrl, decode_token.Token.RawToken);
            ViewBag.Notif = notif;

            ViewBag.Path = Request.Path.Value;
            ViewBag.IdleTime = decode_token.Config.IdleTimeMinutes;
            ViewBag.Company = decode_token.Company;
            ViewBag.MenuData = HelperClient.SetMenu(menu.Result);
            ViewBag.Permission = permission.Permission;
            ViewBag.Menu = menu.Result;
            ViewBag.CurrentMenu = permission.CurrentCode;

            _ = AddActivity(Request.Path.Value, decode_token.Token.BaseApiUrl, decode_token.Token.RawToken);
        }

        #region Check Permission
        private (bool Success, List<string> Permission, string CurrentCode) Permission(RouteValueDictionary route, List<PageResponse> menu)
        {
            string current_controller = route["controller"].ToString();
            string current_action = route["action"].ToString();
            if (current_controller.Trim().ToLower() == "home" && current_action.Trim().ToLower() == "refreshtoken")
                return (true, null, null);

            var permission = new List<PageNavigationPermission>();
            #region Set Permission
            foreach (var m in menu)
            {
                if (m.Navigation.Split('/').Count() > 1)
                    permission.Add(new PageNavigationPermission() { Controller = m.Navigation.Split('/')[0], Action = m.Navigation.Split('/')[1], Permission = m.Permission, Code = m.Code });
                if (m.Childs != null && m.Childs.Count() > 0)
                {
                    foreach (var c in m.Childs)
                    {

                        if (c.Navigation.Split('/').Count() > 1)
                            permission.Add(new PageNavigationPermission() { Controller = c.Navigation.Split('/')[0], Action = c.Navigation.Split('/')[1], Permission = c.Permission, Code = c.Code });
                    }
                }
            }
            #endregion

            var controllers = permission.Where(d => d.Controller.Trim().ToLower() == current_controller.Trim().ToLower()).ToList();
            if (controllers == null || controllers.Count() == 0)
                return (false, null, null);

            var page_action = controllers.Where(d => d.Action.Trim().ToLower() == current_action.Trim().ToLower()).FirstOrDefault();
            if (page_action != null)
                return (true, page_action.Permission, page_action.Code);

            foreach (var c in controllers)
            {
                if (c.Permission != null && c.Permission.Any(d => d.Trim().ToLower() == current_action.Trim().ToLower()))
                    return (true, c.Permission, c.Code);
            }
            return (false, null, null);
        }
        #endregion

        private async Task AddActivity(string pageName, string baseUrl, string token)
        {
            try
            {
                var addActivity = await _logService.AddActivity(pageName, baseUrl, token);
            }
            catch
            {
            }
        }
    }
    internal class PageNavigationPermission
    {
        public string Code { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public List<string> Permission { get; set; }
    }
}