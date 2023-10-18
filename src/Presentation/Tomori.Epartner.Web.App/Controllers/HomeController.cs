using AutoMapper.Internal;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tomori.Epartner.Web.App.Helper;
using Tomori.Epartner.Web.App.Models;
using Tomori.Epartner.Web.Component.Services;
using System.Diagnostics;

namespace Tomori.Epartner.Web.App.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        protected IConfigService _configService;
        public HomeController(IConfigService configService)
        {
            _configService = configService;
        }

        public IActionResult Index()
        {
            ViewBag.Breadcrumb = new List<BreadcrumbModel>
            {
                new BreadcrumbModel("Home", "/",true)
            };
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Counter()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Dokumentasi()
        {
            return View();
        }
        public IActionResult FAQ()
        {
            return View();
        }
        public IActionResult Bantuan()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Notification()
        {
            ViewBag.Breadcrumb = new List<BreadcrumbModel>
            {
                new BreadcrumbModel("Home", "/"),
                new BreadcrumbModel("Notification", "#", true)
            };
            return View();
        }

        public async Task<IActionResult> NotificationClick(Guid id,string url)
        {
            await _notificationService.Open(id, _tokenData.BaseApiUrl, _tokenData.RawToken);
            if (!string.IsNullOrWhiteSpace(url))
            {
                if (!url.StartsWith("/") && url != "#")
                    url = "/" + url;
                return Redirect(url);
            }
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken()
        {
            if (_tokenData == null)
                return null;
            var request = await _userService.RefreshToken(_tokenData.BaseApiUrl, _tokenData.RefreshToken);
            if (request.Succeeded)
            {
                var setting = await _configService.GetSetting(_tokenData.BaseApiUrl, request.Data.RawToken);
                var company = await _configService.GetCompany(_tokenData.BaseApiUrl, request.Data.RawToken);
                var identity = _token.CreateToken(request.Data, setting.Data, company.Data);
                await HttpContext.SignInAsync(HelperClient.AUTHENTICATION_SCHEMA, identity.principal, identity.properties);
                return Content("OK");
            }
            else
                return Content(request.Message);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}