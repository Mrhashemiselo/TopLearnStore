using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.Security;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Entities.Users;

namespace TopLearn.Web.Pages.Admin.Roles;

[PermissionChecker(6)]
public class IndexModel(IRoleServices roleServices) : PageModel
{
    public List<Role> RolesList { get; set; }

    public void OnGet()
    {
        RolesList = roleServices.GetRoles();
    }
}
