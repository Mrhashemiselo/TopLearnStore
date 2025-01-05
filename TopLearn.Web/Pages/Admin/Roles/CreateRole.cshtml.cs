using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.Security;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Entities.Users;

namespace TopLearn.Web.Pages.Admin.Roles;

[PermissionChecker(7)]
public class CreateRoleModel(IPermissionServices permissionService,
    IRoleServices roleServices) : PageModel
{
    [BindProperty]
    public Role Role { get; set; }

    public void OnGet()
    {
        ViewData["Permissions"] = permissionService.GetAllPermission();
    }

    public IActionResult OnPost(List<int> SelectedPermission)
    {
        if (!ModelState.IsValid)
            return Page();


        Role.IsDelete = false;
        int roleId = roleServices.AddRole(Role);

        permissionService.AddPermissionsToRole(roleId, SelectedPermission);

        return RedirectToPage("Index");
    }
}