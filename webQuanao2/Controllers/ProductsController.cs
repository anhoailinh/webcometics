using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webQuanao2.Data;
using webQuanao2.Models;
using webQuanao2.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace webQuanao2.Controllers
{
    public class ProductsController : Controller
    {
        private readonly webQuanao2Context _context;
        public int PageSize = 12;


		public ProductsController(webQuanao2Context context)
        {
            _context = context;
        }
		//size


		public async Task<IActionResult> Size( HttpContext httpContext,int ProductPage = 1)
		{
			int PageSize = 10; // Số sản phẩm hiển thị trên mỗi trang

			var products = await _context.Products
				.Skip((ProductPage - 1) * PageSize)
				.Take(PageSize)
				.ToListAsync();

			var totalProductsCount = await _context.Products.CountAsync();

			

			// Lấy danh sách kích thước dựa trên địa chỉ IP sản phẩm
			var ipAddress = GetIpAddress(httpContext);
			var ipAsInt = IPAddress.Parse(ipAddress).Address;

			var product = await _context.Products
				.Include(p => p.Size)
				.FirstOrDefaultAsync(p => p.SizeId == ipAsInt);

			var sizes = new List<Size>();
			if (product?.Size != null)
			{
				var size = new Size { SizeName = product.Size.SizeName }; // Tạo đối tượng Size từ chuỗi kích thước
				sizes.Add(size);
			}

			var viewModel = new ProductListViewModel
			{
				Products = products,
				PagingInfo = new PagingInfo
				{
					ItemsPerPage = PageSize,
					CurentPage = ProductPage,
					TotalItems = totalProductsCount
				},

				Sizes = sizes // Gán danh sách kích thước vào thuộc tính Sizes của ViewModel
			};

			return View(viewModel);
		}

		public string GetIpAddress(HttpContext httpContext)
		{
			var ipAddress = string.Empty;

			if (httpContext != null)
			{
				ipAddress = httpContext.Connection.RemoteIpAddress?.ToString();
			}

			return ipAddress;
		}
		//phan trang
		public async Task<IActionResult> Index(int ProductPage = 1)
		{
			return View(
				new ProductListViewModel
				{
					Products = _context.Products
				.Skip((ProductPage - 1) * PageSize)
				.Take(PageSize),
					PagingInfo = new PagingInfo
					{
						ItemsPerPage = PageSize,
						CurentPage = ProductPage,
						TotalItems = _context.Products.Count()

					}
				}

				);


		}


		//tìm kiếm 
		[HttpPost]
		public async Task<IActionResult> Seach(string keywords, int ProductPage = 1)
		{
			return View("Index",
				new ProductListViewModel
				{
					Products = _context.Products
					.Where(p => p.Name.Contains(keywords))
				.Skip((ProductPage - 1) * PageSize)
				.Take(PageSize),
					PagingInfo = new PagingInfo
					{
						ItemsPerPage = PageSize,
						CurentPage = ProductPage,
						TotalItems = _context.Products.Count()

					}
				}

				);

		}
		//lọc
		public class PriceRange
		{
			public int Min { get; set; }
			public int Max { get; set; }
		}
		public IActionResult GetFilterProducts([FromBody] FilterData filter)
		{
			var filterProducts = _context.Products.ToList();
			if (filter.PriceRanges != null && filter.PriceRanges.Count > 0 && !filter.PriceRanges.Contains("All"))
			{
				List<PriceRange> priceRanges = new List<PriceRange>();
				foreach (var range in filter.PriceRanges)
				{
					var value = range.Split("-").ToArray();
					PriceRange priceRange = new PriceRange();
					priceRange.Min = Int16.Parse(value[0]);
					priceRange.Max = Int16.Parse(value[1]);
					priceRanges.Add(priceRange);
				}
				filterProducts = filterProducts.Where(p => priceRanges.Any(r => p.Price >= r.Min && p.Price <= r.Max)).ToList();

			}
			if (filter.Colors != null && filter.Colors.Count > 0 && !filter.Colors.Contains("All"))
			{
				filterProducts = filterProducts.Where(p => filter.Colors.Contains(p.Color.ColorName)).ToList();

			}
			if (filter.Sizes != null && filter.Sizes.Count > 0 && !filter.Sizes.Contains("All"))
			{
				filterProducts = filterProducts.Where(p => filter.Sizes.Contains(p.Size.SizeName)).ToList();

			}
			return PartialView("_ReturnProduct", filterProducts);

		}

		//danh mục index
		

		public async Task<IActionResult> category(int? Catid, int ProductPage = 1)
		{
           
				return View("Index",
				new ProductListViewModel
				{
					Products = _context.Products.Where(p => p.CategoryID == Catid)
				.Skip((ProductPage - 1) * PageSize)
				.Take(PageSize),
					PagingInfo = new PagingInfo
					{
						ItemsPerPage = PageSize,
						CurentPage = ProductPage,
						TotalItems = _context.Products.Count()

					}
				}

				);
			
			

		}
		// GET: Products2
		

		// GET: Products/Details/5
      

        
        
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.Color)
                .Include(p => p.Size)
                .Include(p => p.category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Products/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["ColorId"] = new SelectList(_context.Color, "ColorId", "ColorId");
            ViewData["SizeId"] = new SelectList(_context.Size, "SizeId", "SizeName");
            ViewData["CategoryID"] = new SelectList(_context.Category, "Id", "Id");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Descriptionall,ImageUrl,Img1,Img2,Img3,Price,ProductsHot,Quatity,Discount,CategoryID,ColorId,SizeId")] Products products)
        {
            if (ModelState.IsValid)
            {
                _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColorId"] = new SelectList(_context.Color, "ColorId", "ColorId", products.ColorId);
            ViewData["SizeId"] = new SelectList(_context.Size, "SizeId", "SizeName", products.SizeId);
            ViewData["CategoryID"] = new SelectList(_context.Category, "Id", "Id", products.CategoryID);
            return View(products);
        }

        // GET: Products/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            ViewData["ColorId"] = new SelectList(_context.Color, "ColorId", "ColorId", products.ColorId);
            ViewData["SizeId"] = new SelectList(_context.Size, "SizeId", "SizeName", products.SizeId);
            ViewData["CategoryID"] = new SelectList(_context.Category, "Id", "Id", products.CategoryID);
            return View(products);
        }

        // POST: Products/Edit/5

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
      
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Descriptionall,ImageUrl,Img1,Img2,Img3,Price,ProductsHot,Quatity,Discount,CategoryID,ColorId,SizeId")] Products products)
        {
            if (id != products.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColorId"] = new SelectList(_context.Color, "ColorId", "ColorId", products.ColorId);
            ViewData["SizeId"] = new SelectList(_context.Size, "SizeId", "SizeName", products.SizeId);
            ViewData["CategoryID"] = new SelectList(_context.Category, "Id", "Id", products.CategoryID);
            return View(products);
        }

        // GET: Products/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.Color)
                .Include(p => p.Size)
                .Include(p => p.category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
     
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'webQuanao2Context.Products'  is null.");
            }
            var products = await _context.Products.FindAsync(id);
            if (products != null)
            {
                _context.Products.Remove(products);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
          return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
