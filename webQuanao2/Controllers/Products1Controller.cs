using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webQuanao2.Data;
using webQuanao2.Models;

namespace webQuanao2.Controllers
{
    public class Products1Controller : Controller
    {
        private readonly webQuanao2Context _context;

        public Products1Controller(webQuanao2Context context)
        {
            _context = context;
        }

        // GET: Products1
        public async Task<IActionResult> Index()
        {
            var webQuanao2Context = _context.Products.Include(p => p.Color).Include(p => p.Size).Include(p => p.category);
            return View(await webQuanao2Context.ToListAsync());
        }

        // GET: Products1/Details/5
        [Authorize]
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

        // GET: Products1/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["ColorId"] = new SelectList(_context.Color, "ColorId", "ColorId");
            ViewData["SizeId"] = new SelectList(_context.Size, "SizeId", "SizeName");
            ViewData["CategoryID"] = new SelectList(_context.Category, "Id", "Id");
            return View();
        }

        // POST: Products1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
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

        // GET: Products1/Edit/5
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

        // POST: Products1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
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

        // GET: Products1/Delete/5
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

        // POST: Products1/Delete/5
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
