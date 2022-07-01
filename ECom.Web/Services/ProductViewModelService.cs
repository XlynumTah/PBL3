using ECom.DataAccess.Data;
using ECom.Models;
using ECom.Web.Interfaces;
using ECom.Web.ViewModels;
using ECom.Web.ExtensionsMethod;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

#nullable disable
namespace ECom.Web.Services;

public class ProductViewModelService:IProductViewModelService
{
    private readonly ILogger<ProductViewModelService> _logger;
    private readonly ApplicationDbContext _context;

    public ProductViewModelService(
        ILoggerFactory loggerFactory,
        ApplicationDbContext context)
    {
        _logger = loggerFactory.CreateLogger<ProductViewModelService>();
        _context = context;
    }
    public async Task<ProductIndexViewModel> GetProductItemsAsync(int pageIndex, int itemsPage, string? name, int? manufactureId, int? categoryId)
    {
        _logger.LogInformation("GetProductItems called");
        var filteredQuery = _context.Products.GetAllAvailbleProduct().Include(p=>p.Manufacture).Where(p =>
            (!manufactureId.HasValue || p.ManufactureId == manufactureId) &&
            (!categoryId.HasValue || p.CategoryId == categoryId) && ( String.IsNullOrEmpty(name)|| p.Name.Contains(name)));
        var itemOnPage = await filteredQuery
            .Skip(itemsPage * pageIndex).Take(itemsPage).ToListAsync();
        var totalItem = await filteredQuery.CountAsync();
        var vm = new ProductIndexViewModel()
        {
            ProductItems = itemOnPage.Select(p => new ProductItemViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                ImageUrl = p.ImageUrl,
                DPrice = Decimal.ToInt32(p.Price*(1-p.Discount)),
                Price = Decimal.ToInt32(p.Price),
                Discount = Decimal.ToInt32(p.Discount*100),
                Category=p.CategoryId.ToString()
            }).ToList(),
            Manufactures = (await GetManufacturesAsync()).ToList(),
            Categories = (await GetCategoryAsync()).ToList(),
            NameFilterApplied = name ?? "",
            ManufactureFilterApplied = manufactureId ?? 0,
            CategoryFilterApplied = categoryId ?? 0,
            PaginationInfo = new PaginationInfoViewModel()
            {
                ActualPage = pageIndex,
                ItemsPerPage = itemOnPage.Count,
                TotalItems = totalItem,
                TotalPages = int.Parse(Math.Ceiling(((decimal)totalItem/itemsPage)).ToString())
            }
        };
        vm.PaginationInfo.Next=(vm.PaginationInfo.ActualPage==vm.PaginationInfo.TotalPages-1)?"is-disabled":"";
        vm.PaginationInfo.Previous = (vm.PaginationInfo.ActualPage == 0) ? "is-disabled" : "";

        return vm;
    }

    public async Task<IEnumerable<SelectListItem>> GetManufacturesAsync()
    {
        _logger.LogInformation("GetManufactuesAsync called.");
        var manufactures = await _context.Manufactures.ToListAsync();
        var items = manufactures
            .Select(m => new SelectListItem() {Value = m.Id.ToString(), Text = m.Name})
            .OrderBy(m => m.Text)
            .ToList();
        var allItem = new SelectListItem() {Value = null, Text = "Tất cả nhãn hàng", Selected = true};
        items.Insert(0,allItem);
        return items;
    }

    public async Task<IEnumerable<SelectListItem>> GetCategoryAsync()
    {
        _logger.LogInformation("GetManufactuesAsync called.");
        var categories = await _context.Categories.ToListAsync();
        var items = categories
            .Select(m => new SelectListItem() {Value = m.Id.ToString(), Text = m.Name})
            .OrderBy(m => m.Text)
            .ToList();
        var allItem = new SelectListItem() {Value = null, Text = "Tất cả ngành hàng", Selected = true};
        items.Insert(0,allItem);
        return items;
    }
}