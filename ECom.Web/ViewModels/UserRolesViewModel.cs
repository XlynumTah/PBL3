using Microsoft.AspNetCore.Mvc.Rendering;


#nullable disable

namespace ECom.Web.ViewModels;
public class UserRolesViewMode
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public List<SelectListItem> Roles { get; set; }
    public string CurrentRole { get; set; }
}