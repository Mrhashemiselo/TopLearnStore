using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.DTOs.Users;
using TopLearn.Core.Services.Interfaces;

namespace TopLearn.Web.Pages.Admin.Users;

public class CreateUserModel(IAdminPanel adminPanel,
    IPermissionService permissionService) : PageModel
{
    [BindProperty]
    public CreateUserViewModel CreateUserViewModel { get; set; }

    public void OnGet()
    {
        ViewData["Roles"] = permissionService.GetRoles();
    }

    public IActionResult OnPost(List<int> SelectedRoles)
    {
        if (!ModelState.IsValid)
            return Page();

        int userId = adminPanel.AddUserFromAdmin(CreateUserViewModel);

        permissionService.AddRolesToUser(SelectedRoles, userId);

        return Redirect("/Admin/Users");
    }
}
