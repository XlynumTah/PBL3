using ECom.Web.ViewModels;

namespace ECom.Web.Interfaces;

public interface IUserRolesViewModelService
{
    Task<UserRolesViewMode> GetUserRolesViewModelAsync(int userId);
    Task UpdateUserRolesAsync(UserRolesViewMode viewModel);
}