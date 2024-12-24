using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.DTOs.AdminPanel;
using TopLearn.Core.Services.Interfaces;

namespace TopLearn.Web.Pages.Admin.Users;

public class DeletedUsersModel(IAdminPanel adminPanel) : PageModel
{
    public UserForAdminViewModel UserForAdminViewModel { get; set; }

    public void OnGet(int pageId = 1, string filterUsername = "", string filterEmail = "")
    {
        UserForAdminViewModel = adminPanel.GetDeletedUsers(pageId, filterEmail, filterUsername);
    }
}
