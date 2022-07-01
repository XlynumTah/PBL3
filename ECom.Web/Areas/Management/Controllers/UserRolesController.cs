using ECom.Models;
using ECom.Web.Interfaces;
using ECom.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECom.Web.Areas.Management.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Management")]
    public class UserRolesController : Controller
    {
        private readonly IUserRolesViewModelService _userRolesViewModelService;
        private readonly ILogger<UserRolesController> _logger;

        public UserRolesController(IUserRolesViewModelService userRolesViewModelService, ILoggerFactory loggerFactory)
        {
            _userRolesViewModelService = userRolesViewModelService;
            _logger = loggerFactory.CreateLogger<UserRolesController>();
        }
        // GET
        public async Task<IActionResult> IndexAsync(int userId)
        {
            _logger.LogWarning("Index get called");
            var viewModel = await _userRolesViewModelService.GetUserRolesViewModelAsync(userId);
            return View(viewModel);
        }
        //POST
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> IndexAsync(UserRolesViewMode viewModel)
        {
            _logger.LogWarning("Index post called");
            if (!ModelState.IsValid) return BadRequest();
            await _userRolesViewModelService.UpdateUserRolesAsync(viewModel);
            return RedirectToAction("Index", "Users");
        }
    }
}
