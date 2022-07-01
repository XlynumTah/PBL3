using ECom.DataAccess.Data;
using ECom.Models;
using ECom.Web.Interfaces;
using ECom.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECom.Web.Areas.Customer.Pages.Orders;
[Authorize(Roles="Admin,User")]
public class IndexModel : PageModel
{
    private readonly IOrderViewModelService _orderViewModelServices;
    private readonly UserManager<ApplicationUser> _userManager;

    public IndexModel(IOrderViewModelService orderViewModelService,
        UserManager<ApplicationUser> userManager)
    {
        _orderViewModelServices = orderViewModelService;
        _userManager = userManager;
    }
    public List<OrderViewModel> AllUserOrders { get; set; }
    public async Task OnGetAsync()
    {
        var currentUser = await _userManager.GetUserAsync(HttpContext.User);
        AllUserOrders = await _orderViewModelServices.GetAllOrderAsync(currentUser.Id);
    }
}