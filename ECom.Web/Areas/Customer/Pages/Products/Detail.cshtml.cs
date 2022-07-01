using ECom.DataAccess.Data;
using ECom.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EComWeb.Areas.Customer.Pages.Products;
public class DetailModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<DetailModel> _logger;
    public Product Product { get; set; }
    public DetailModel(ApplicationDbContext context, ILoggerFactory loggerFactory)
    {
        _context = context;
        _logger = loggerFactory.CreateLogger<DetailModel>();
    }
    public async Task<IActionResult> OnGet(int id)
    {
        if (id == null || _context.Products == null)
        {
            return NotFound();
        }
        _logger.LogWarning($"Details get with id {id} called");
        Product = await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Manufacture)
            .Include(p=>p.Specification)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (Product == null)
        {
            return NotFound();
        }

        return Page();
    }
}