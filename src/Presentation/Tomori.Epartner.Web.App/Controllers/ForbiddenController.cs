using Microsoft.AspNetCore.Mvc;

namespace Tomori.Epartner.Web.App.Controllers
{

	public class ForbiddenController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
