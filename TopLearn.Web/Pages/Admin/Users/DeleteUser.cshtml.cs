using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.DTOs.UserPanel;
using TopLearn.Core.Services.Interfaces;

namespace TopLearn.Web.Pages.Admin.Users;

public class DeleteUserModel(IUserPanelServices userPanelServices,
    IUserServices userServices) : PageModel
{
    public InformationUserViewModel InformationUserViewModel { get; set; }
    public void OnGet(int id)
    {
        ViewData["UserId"] = id;
        InformationUserViewModel = userPanelServices.GetUserInformation(id);
    }

    public IActionResult OnPost(int userId)
    {
        userServices.DeleteUser(userId);
        return RedirectToPage("Index");
    }
}
