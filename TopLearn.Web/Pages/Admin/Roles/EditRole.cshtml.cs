using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Entities.Users;

namespace TopLearn.Web.Pages.Admin.Roles;

public class EditRoleModel(IPermissionService permissionService, IRoleServices roleServices) : PageModel
{
    [BindProperty]
    public Role Role { get; set; }
    public void OnGet(int id)
    {
        Role = roleServices.GetRoleById(id);
        ViewData["Permissions"] = permissionService.GetAllPermission();
        ViewData["SelectedPermissions"] = permissionService.PermissionsRole(id);
    }

    public IActionResult OnPost(List<int> SelectedPermission)
    {
        if (!ModelState.IsValid)
            return Page();


        roleServices.UpdateRole(Role);

        permissionService.UpdatePermissionsRole(Role.Id, SelectedPermission);

        return RedirectToPage("Index");
    }
}