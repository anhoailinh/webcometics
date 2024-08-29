using Microsoft.AspNetCore.Mvc;
using webQuanao2.Data;
using webQuanao2.Infrastructure;


namespace webQuanao2.Models
{
	public class Carticon : ViewComponent
	{
		
		public IViewComponentResult Invoke()
		{
			return View(HttpContext.Session.GetJson<Cart>("cart"));
		}
	}
}
