using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using ECom.Web.ExtensionsMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECom.DataAccess.Data;
using ECom.Models;
using Microsoft.AspNetCore.Authorization;

namespace ECom.Web.Areas.Management.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Management")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment,
            ILoggerFactory loggerFactory)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            _logger = loggerFactory.CreateLogger<ProductsController>();
        }

        // GET: Products
        public async Task<IActionResult> Index(string name="")
        {
            _logger.LogWarning("Index get called");
            var result = _context.Products.Where(p=>String.IsNullOrEmpty(name)?true:p.Name.Contains(name))
                .Include(p => p.Category)
                .Include(p => p.Manufacture)
                .Include(p=>p.Specification);
            return View(await result.ToListAsync());
        }
        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }
            _logger.LogWarning($"Details get with id {id} called");
            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Manufacture)
                .Include(p=>p.Specification)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["ManufactureId"] = new SelectList(_context.Manufactures, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ReleaseDate,CategoryId,ManufactureId,Description,Price,Discount,Quantity,Image,IsDeleted")] Product product)
        {
            if (ModelState.IsValid)
            {
                _logger.LogWarning("Create method called, Model state valid");
                string webRootPath = _hostEnvironment.WebRootPath;
                await product.SaveImageAsync(webRootPath);
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            ViewData["ManufactureId"] = new SelectList(_context.Manufactures, "Id", "Name", product.ManufactureId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.Include(p=>p.Specification).FirstOrDefaultAsync(p=>p.Id==id);
            if (product == null)
            {
                return NotFound();
            }

            product.LoadImage(_hostEnvironment.WebRootPath);
            
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            ViewData["ManufactureId"] = new SelectList(_context.Manufactures, "Id", "Name", product.ManufactureId);
            return View(product);
        }
        
        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ReleaseDate,CategoryId,ManufactureId,Description,Price,Discount,Quantity,ImageUrl,IsDeleted")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _logger.LogWarning("Edit method called, Model state valid");
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            ViewData["ManufactureId"] = new SelectList(_context.Manufactures, "Id", "Name", product.ManufactureId);
            return View(product);
        }
        // GET
        public async Task<IActionResult> EditImage(int id)
        {
            if (await _context.Products.FindAsync(id) ==null)
            {
                return NotFound();
            }
            return View(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditImage([Bind("id,image")]int id, IFormFile image)
        {
            var product = await _context.Products.FindAsync(id);
            if (product ==null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string webRootPath = _hostEnvironment.WebRootPath;
                await product.EditImageAsync(_hostEnvironment.WebRootPath, image);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Edit", routeValues: new {id=id});
        }
        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Manufacture)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                product.RemoveImage(_hostEnvironment.WebRootPath);
                _context.Products.Remove(product);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Products.Any()?true:false);
        }
    }
}
