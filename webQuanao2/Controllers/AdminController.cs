using Microsoft.AspNetCore.Mvc;

namespace webQuanao2.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
