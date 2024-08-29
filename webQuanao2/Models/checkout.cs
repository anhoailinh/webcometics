using Microsoft.AspNetCore.Mvc;
using webQuanao2.Data;
using webQuanao2.Infrastructure;

namespace webQuanao2.Models
{
	public class checkout: ViewComponent
	{
		private readonly webQuanao2Context _context;

		public checkout(webQuanao2Context context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			return View("Default", HttpContext.Session.GetJson<Cart>("cart"));
		}
	}
}
