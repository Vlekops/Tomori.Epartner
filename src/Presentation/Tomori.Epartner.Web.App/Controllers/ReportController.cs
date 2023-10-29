using Microsoft.AspNetCore.Mvc;

namespace Tomori.Epartner.Web.App.Controllers
{
    public class ReportController : BaseController<ReportController>
    {
        public IActionResult Index()
        {
            ViewBag.Breadcrumb = new List<BreadcrumbModel>
            {
                new BreadcrumbModel("Home", "/"),
                new BreadcrumbModel("Report", "#", true)
            };
            return View();
        }
    }
}
