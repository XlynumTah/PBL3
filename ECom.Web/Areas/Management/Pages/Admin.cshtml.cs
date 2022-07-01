using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECom.Web.Areas.Management.Pages
{
    [Authorize(Roles = "Admin")]
    public class AdminModel : PageModel
    {

        public void  OnGet()
        {
        }
    }
}