using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webQuanao2.Data;

using webQuanao2.Infrastructure;
using webQuanao2.Models;


namespace webQuanao2.Controllers
{
	public class CartController : Controller
	{
		public Cart? Cart { get; set; }
		private readonly webQuanao2Context _context;

		public CartController(webQuanao2Context context)
		{
			_context = context;
		}
        public IActionResult Index()
        {
            return View("Cart", HttpContext.Session.GetJson<Cart>("cart"));

        }
		//checkout
		public IActionResult checkout()
		{
			return View("checkout", HttpContext.Session.GetJson<Cart>("cart"));

		}

		[Authorize]
		public IActionResult AddToCart(int productId)
		{

			Products? product = _context.Products
				.FirstOrDefault(p => p.Id == productId);
			if (product != null)
			{
				Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
				Cart.AddItem(product, 1);
				HttpContext.Session.SetJson("cart", Cart);

			}
			return View("Cart", Cart);
		}
        [Authorize]
        public IActionResult UpdateToCart(int productId)
		{
			Products? product = _context.Products
				.FirstOrDefault(p => p.Id == productId);
			if (product != null)
			{
				Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
				Cart.AddItem(product, -1);
				HttpContext.Session.SetJson("cart", Cart);

			}
			return View("Cart", Cart);
		}
        [Authorize]
        public IActionResult RemoveFromCart(int productId)
		{
			Products? product = _context.Products
				.FirstOrDefault(p => p.Id == productId);
			if (product != null)
			{
				Cart = HttpContext.Session.GetJson<Cart>("cart");
				Cart.RemoveLine(product);
				HttpContext.Session.SetJson("cart", Cart);

			}
			return View("Cart", Cart);
		}

	}
}