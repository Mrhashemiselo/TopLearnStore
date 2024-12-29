using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Entities.Users;

namespace TopLearn.Web.Pages.Admin.Roles;

public class DeleteRoleModel(IRoleServices roleServices) : PageModel
{
    [BindProperty]
    public Role Role { get; set; }
    public void OnGet(int id)
    {
        Role = roleServices.GetRoleById(id);
    }

    public IActionResult OnPost()
    {
        roleServices.DeleteRole(Role);

        return RedirectToPage("Index");
    }

}