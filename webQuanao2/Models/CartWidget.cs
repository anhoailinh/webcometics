using Microsoft.AspNetCore.Mvc;

using webQuanao2.Data;
using webQuanao2.Infrastructure;
using webQuanao2.Models;
namespace webQuanao2.Models
{
    public class CartWidget : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(HttpContext.Session.GetJson<Cart>("cart"));
        }
    }
}
