using Microsoft.AspNetCore.Mvc;
using webQuanao2.Data;

namespace webQuanao2.Models
{
	public class Seach: ViewComponent
	{
		private readonly webQuanao2Context _context;

		public Seach(webQuanao2Context context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			return View(_context.Products.ToList());
		}
	}
}
