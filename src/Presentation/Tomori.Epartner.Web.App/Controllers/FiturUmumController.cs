using Microsoft.AspNetCore.Mvc;

namespace Tomori.Epartner.Web.App.Controllers
{
    public class FiturUmumController : BaseController<FiturUmumController>
    {
        public new IActionResult User()
        {
            ViewBag.Breadcrumb = new List<BreadcrumbModel>
            {
                new BreadcrumbModel("Home", "/"),
                new BreadcrumbModel("User", "#", true)
            };
            return View();
        }
        public IActionResult Delegasi()
        {
            ViewBag.Breadcrumb = new List<BreadcrumbModel>
            {
                new BreadcrumbModel("Home", "/"),
                new BreadcrumbModel("Delegasi", "#", true)
            };
            return View();
        }
        public IActionResult Workflow()
        {
            ViewBag.Breadcrumb = new List<BreadcrumbModel>
            {
                new BreadcrumbModel("Home", "/"),
                new BreadcrumbModel("Workflow", "#", true)
            };
            return View();
        }
        public IActionResult DocumentTemplate()
        {
            ViewBag.Breadcrumb = new List<BreadcrumbModel>
            {
                new BreadcrumbModel("Home", "/"),
                new BreadcrumbModel("Document Template", "#", true)
            };
            return View();
        }
        public IActionResult Report()
        {
            ViewBag.Breadcrumb = new List<BreadcrumbModel>
            {
                new BreadcrumbModel("Home", "/"),
                new BreadcrumbModel("Report", "#", true)
            };
            return View();
        }
        public IActionResult Audit()
        {
            ViewBag.Breadcrumb = new List<BreadcrumbModel>
            {
                new BreadcrumbModel("Home", "/"),
                new BreadcrumbModel("Audit", "#", true)
            };
            return View();
        }
        public IActionResult Page()
        {
            ViewBag.Breadcrumb = new List<BreadcrumbModel>
            {
                new BreadcrumbModel("Home", "/"),
                new BreadcrumbModel("Page", "#", true)
            };
            return View();
        }
        public IActionResult Role()
        {
            ViewBag.Breadcrumb = new List<BreadcrumbModel>
            {
                new BreadcrumbModel("Home", "/"),
                new BreadcrumbModel("Role", "#", true)
            };
            return View();
        }
        public IActionResult PdfTemplate()
        {
            ViewBag.Breadcrumb = new List<BreadcrumbModel>
            {
                new BreadcrumbModel("Home", "/"),
                new BreadcrumbModel("PdfTemplate", "#", true)
            };
            return View();
        }
        public IActionResult Config()
        {
            ViewBag.Breadcrumb = new List<BreadcrumbModel>
            {
                new BreadcrumbModel("Home", "/"),
                new BreadcrumbModel("Configuration", "#", true)
            };
            return View();
        }


    }
}
