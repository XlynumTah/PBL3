using ECom.Models;
using ECom.Web.Interfaces;
using ECom.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECom.Web.Areas.Customer.Pages.Basket;

[Authorize(Roles="Admin,User")]
public class CheckoutModel : PageModel
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IBasketViewModelService _basketViewModelService;
    private readonly IBasketService _basketService;
    private readonly IOrderService _orderService;

    public CheckoutModel(SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager,
        IBasketViewModelService basketViewModelService,
        IBasketService basketService,
        IOrderService orderService)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _basketViewModelService = basketViewModelService;
        _basketService = basketService;
        _orderService = orderService;
    }

    public BasketViewModel BasketViewModel { get; set; } = new BasketViewModel();

    public async Task OnGetAsync()
    {
        await SetBasketViewModelAsync();
    }

    public async Task<IActionResult> OnPostAsync(IEnumerable<BasketItemViewModel> items)
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        await SetBasketViewModelAsync();
        var updateModel = items.ToDictionary(b => b.Id.ToString(), b => b.Quantity);
        await _basketService.SetQuantitesAsync(BasketViewModel.Id, updateModel);
        await _orderService.CreateOrderAsync(BasketViewModel.Id, user.Address);
        await _basketService.DeleteBasketAsync(BasketViewModel.Id);
        return RedirectToPage("Success");
    }

    private async Task SetBasketViewModelAsync()
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        BasketViewModel = await _basketViewModelService.GetOrCreateBasketViewModelForUserAsync(user.Id);
    }
}