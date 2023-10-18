using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tomori.Epartner.Web.App.Helper;
using Tomori.Epartner.Web.Component.Helpers;
using Tomori.Epartner.Web.Component.Models;
using Tomori.Epartner.Web.Component.Services;
using System.Reflection;

namespace Tomori.Epartner.Web.App.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserService _userService;
        private readonly IConfigService _configService;
        private readonly IPageService _pageService;
        private readonly ITokenHelper _token;
        private string BASE_URL = "";

        public AccountController(ILogger<AccountController> logger,
            IUserService userService,
            IConfigService configService,
            IPageService pageService,
            IConfiguration configuration,
            ITokenHelper token)
        {

            BASE_URL = configuration.GetValue<string>("APIUrl");
            _userService = userService;
            _configService = configService;
            _pageService = pageService;
            _logger = logger;
            _token = token;
        }

        #region Login
        public IActionResult Login(string redirect)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction(redirect);
            else
                return View();
        }
        [HttpPost]
        public async Task<JsonResult> Login([FromBody] LoginModel model)
        {
            var result = new StatusResponse();
            try
            {
                var res = await _userService.Login(model.Username, model.Password, BASE_URL);
                if (res.Succeeded)
                {
                    var setting = await _configService.GetSetting(BASE_URL, res.Data.RawToken);
                    var company = await _configService.GetCompany(BASE_URL, res.Data.RawToken);
                    var identity = _token.CreateToken(res.Data, setting.Data, company.Data);
                    var page_user = await _pageService.GetByUser(BASE_URL, res.Data.RawToken);
                    if (page_user.Succeeded)
                    {
                        var page_cookies = HelperClient.SetPage(page_user.List, res.Data.ExpiredAt);
                        Response.Cookies.Append(HelperClient.PAGE_COOKIE, page_cookies.result);
                    }
                    await HttpContext.SignInAsync(HelperClient.AUTHENTICATION_SCHEMA, identity.principal, identity.properties);

                    result.OK();
                }
                else
                {
                    result = new StatusResponse()
                    {
                        Code = res.Code,
                        Description = res.Description,
                        Message = res.Message,
                        Succeeded = res.Succeeded
                    };
                }
            }
            catch (Exception ex)
            {
                result.Error(ex.Message, ex.InnerException?.ToString() ?? "");
            }
            return Json(result);
        }
        #endregion

        #region Forgot Password Send Mail
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> ForgotPassword(string email)
        {
            var result = new StatusResponse();
            try
            {
                var res = await _userService.SendForgotPassword(email, BASE_URL);
                if (res.Succeeded)
                {
                    result.OK();
                }
                else
                {
                    result = new StatusResponse()
                    {
                        Code = res.Code,
                        Description = res.Description,
                        Message = res.Message,
                        Succeeded = res.Succeeded
                    };
                }
            }
            catch (Exception ex)
            {
                result.Error(ex.Message, ex.InnerException?.ToString() ?? "");
            }
            return Json(result);
        }
        #endregion

        #region Reset Password
        public async Task<IActionResult> ResetPassword(string token)
        {
            var res = await _userService.CheckToken(token, BASE_URL);
            if (!res.Succeeded)
            {
                return RedirectToAction("Index", "Forbidden");
            }
            ViewBag.Token = token;
            return View();
        }

		public async Task<IActionResult> ChangeResetPassword(string token, string password)
		{
			var result = new StatusResponse();
			try
			{
				var res = await _userService.ResetChangePassword(token, password, BASE_URL);
				if (res.Succeeded)
				{
					return RedirectToAction("Login", "Account");
				}
				else
				{
					result = new StatusResponse()
					{
						Code = res.Code,
						Description = res.Description,
						Message = res.Message,
						Succeeded = res.Succeeded
					};
				}
			}
			catch (Exception ex)
			{
				result.Error(ex.Message, ex.InnerException?.ToString() ?? "");
			}
			return Json(result);
		}

		#endregion

		public async Task<IActionResult> LogOff()
        {
            await DoLogoff();
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public async Task<JsonResult> LogOffRequest()
        {
            return Json(await DoLogoff());
        }
        private async Task<StatusResponse> DoLogoff()
        {
            var result = new StatusResponse();
            result.OK();
            try
            {
                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    var token = _token.DecodeToken(HttpContext);
                    await _userService.Logoff(BASE_URL, token.Token.RawToken);
                    await HttpContext.SignOutAsync(HelperClient.AUTHENTICATION_SCHEMA);
                    Response.Cookies.Delete(HelperClient.PAGE_COOKIE);

                }
            }
            catch (Exception ex)
            {
                result.Error(ex.Message, ex.InnerException.ToString());
            }
            return result;
        }
    }
}
