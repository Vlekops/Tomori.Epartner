using Microsoft.AspNetCore.Mvc;

namespace Tomori.Epartner.Web.App.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ErrorDetail = TempData["ErrorDetail"];

            return View();
        }
    }
}
