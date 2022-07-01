using ECom.Models;
using ECom.Web.Interfaces;
using ECom.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ECom.Web.Services;

public class UserRolesViewModelService:IUserRolesViewModelService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;

    public UserRolesViewModelService(
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
    public async Task<UserRolesViewMode> GetUserRolesViewModelAsync(int userId)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
        var userRole = (await _userManager.GetRolesAsync(user))[0];
        UserRolesViewMode vm = new UserRolesViewMode()
        {
            UserId = userId,
            Username = user.Email,
            CurrentRole= (await _userManager.GetRolesAsync(user))[0],
            Roles = await _roleManager.Roles
                .Select(r=>new SelectListItem(){Value = r.Name,Text = r.Name,Selected = r.Name==userRole}).ToListAsync()
        };

        return vm;
    }

    public async Task UpdateUserRolesAsync(UserRolesViewMode viewModel)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == viewModel.UserId);
        var roles = await _roleManager.Roles.ToListAsync();
        foreach (var role in roles)
        {
            await _userManager.RemoveFromRoleAsync(user, role.Name);
        }
        await _userManager.AddToRoleAsync(user, viewModel.CurrentRole);
    }
}