using ECom.DataAccess.Data;
using ECom.Models;
using ECom.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECom.Web.Areas.Management.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Management")]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IOrderViewModelService _orderViewModelServices;
        private readonly IOrderService _orderService;
        private readonly UserManager<ApplicationUser> _userManager;
        public OrdersController(ApplicationDbContext context, IOrderViewModelService orderViewModelService,
            IOrderService orderService, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _orderViewModelServices = orderViewModelService;
            _orderService = orderService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(int? userId)
        {
            var allUser = await _context.Users.ToListAsync();
            return View(allUser);
        }
        public async Task<IActionResult> GetUserOrders(int userId)
        {
            var allOrders = await _orderViewModelServices.GetAllOrderAsync(userId);
            return View(allOrders);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> UpdateOrderStatus(int orderId, string statusName)
        {
            await _orderService.UpdateOrderStatusAsync(orderId, statusName);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Detail(int orderId)
        {
            var order = await _orderViewModelServices.GetOrderDetailAsync(orderId);
            return View(order);
        }
    }
}
