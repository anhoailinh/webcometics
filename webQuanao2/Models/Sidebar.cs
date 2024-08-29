using Microsoft.AspNetCore.Mvc;
using webQuanao2.Data;

namespace webQuanao2.Models
{
	public class Sidebar : ViewComponent
	{
		private readonly webQuanao2Context _context;

		public Sidebar(webQuanao2Context context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			return View(_context.Category.ToList());
		}
	}
}
