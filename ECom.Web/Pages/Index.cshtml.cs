using ECom.Web.Interfaces;
using ECom.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECom.Web.Pages;

public class IndexModel : PageModel
{
    private readonly IProductViewModelService _productViewModelService;

    public IndexModel(IProductViewModelService productViewModelService)
    {
        _productViewModelService = productViewModelService;
    }

    public ProductIndexViewModel ProductIndexViewModel { get; set; } = new ProductIndexViewModel();

    public async Task OnGetAsync(ProductIndexViewModel productIndexViewModel, int? pageId)
    {
        ProductIndexViewModel = await _productViewModelService.GetProductItemsAsync(pageId ?? 0,
            Constants.ITEMS_PER_PAGE, productIndexViewModel.NameFilterApplied, productIndexViewModel.ManufactureFilterApplied,
            productIndexViewModel.CategoryFilterApplied);
    }
}