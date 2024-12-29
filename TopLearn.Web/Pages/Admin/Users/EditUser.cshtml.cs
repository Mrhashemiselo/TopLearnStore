using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.DTOs.AdminPanel;
using TopLearn.Core.Services.Interfaces;

namespace TopLearn.Web.Pages.Admin.Users;

public class EditUserModel(IAdminPanel adminPanel,
    IRoleServices roleServices) : PageModel
{

    [BindProperty]
    public EditUserViewModel EditUserViewModel { get; set; }

    public void OnGet(int id)
    {
        EditUserViewModel = adminPanel.GetUserForShowInEditMode(id);
        ViewData["Roles"] = roleServices.GetRoles();
    }

    public IActionResult OnPost(List<int> UserRoles)
    {
        if (!ModelState.IsValid)
            return Page();

        adminPanel.EditUserFromAdmin(EditUserViewModel);
        roleServices.EditRoleUser(EditUserViewModel.UserId, UserRoles);
        return RedirectToPage("Index");
    }
}