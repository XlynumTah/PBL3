using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class ManufacturesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManufacturesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Manufactures
        public async Task<IActionResult> Index()
        {
              return _context.Manufactures != null ? 
                          View(await _context.Manufactures.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Manufactures'  is null.");
        }

        // GET: Manufactures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Manufactures == null)
            {
                return NotFound();
            }

            var manufacture = await _context.Manufactures
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manufacture == null)
            {
                return NotFound();
            }

            return View(manufacture);
        }

        // GET: Manufactures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manufactures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] Manufacture manufacture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manufacture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(manufacture);
        }

        // GET: Manufactures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Manufactures == null)
            {
                return NotFound();
            }

            var manufacture = await _context.Manufactures.FindAsync(id);
            if (manufacture == null)
            {
                return NotFound();
            }
            return View(manufacture);
        }

        // POST: Manufactures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Manufacture manufacture)
        {
            if (id != manufacture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manufacture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManufactureExists(manufacture.Id))
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
            return View(manufacture);
        }

        // GET: Manufactures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Manufactures == null)
            {
                return NotFound();
            }

            var manufacture = await _context.Manufactures
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manufacture == null)
            {
                return NotFound();
            }

            return View(manufacture);
        }

        // POST: Manufactures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Manufactures == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Manufactures'  is null.");
            }
            var manufacture = await _context.Manufactures.FindAsync(id);
            if (manufacture != null)
            {
                _context.Manufactures.Remove(manufacture);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManufactureExists(int id)
        {
          return (_context.Manufactures?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
