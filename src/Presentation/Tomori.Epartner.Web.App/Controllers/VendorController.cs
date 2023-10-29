using Microsoft.AspNetCore.Mvc;

namespace Tomori.Epartner.Web.App.Controllers
{
    public class VendorController : BaseController<VendorController>
    {
        public IActionResult Index()
        {
            ViewBag.Breadcrumb = new List<BreadcrumbModel>
            {
                new BreadcrumbModel("Home", "/"),
                new BreadcrumbModel("Vendor", "#", true)
            };
            return View();
        }
        public IActionResult Detail(Guid Id)
        {
            ViewBag.Breadcrumb = new List<BreadcrumbModel>
            {
                new BreadcrumbModel("Home", "/"),
                new BreadcrumbModel("Vendor", "/Vendor/Index"),
                new BreadcrumbModel("Detail", "#", true)
            };
            ViewBag.VendorId = Id;
            return View();
        }


    }
}
