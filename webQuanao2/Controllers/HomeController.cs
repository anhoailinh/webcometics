using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using webQuanao2.Data;
using webQuanao2.Models;

namespace webQuanao2.Controllers
{
	public class HomeController : Controller
	{
        private readonly webQuanao2Context _context;

        public HomeController(webQuanao2Context context)
        {
            _context = context;
        }

        public IActionResult Index()
		{
			var list = _context.Products.Include(x => x.category).ToList();
			return View(list);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}