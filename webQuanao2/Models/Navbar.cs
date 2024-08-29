using Microsoft.AspNetCore.Mvc;
using webQuanao2.Data;

namespace webQuanao2.Models
{
	public class Navbar : ViewComponent
	{
		private readonly webQuanao2Context _context;

		public Navbar(webQuanao2Context context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			return View(_context.Products.ToList());
		}
	}
}
