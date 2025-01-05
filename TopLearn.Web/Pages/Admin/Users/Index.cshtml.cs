using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.DTOs.AdminPanel;
using TopLearn.Core.Security;
using TopLearn.Core.Services.Interfaces;

namespace TopLearn.Web.Pages.Admin.Users;

[PermissionChecker(2)]
public class IndexModel(IAdminPanelServices adminPanel) : PageModel
{
    public UserForAdminViewModel UserForAdminViewModel { get; set; }

    public void OnGet(int pageId = 1, string filterUsername = "", string filterEmail = "")
    {
        UserForAdminViewModel = adminPanel.GetUsers(pageId, filterEmail, filterUsername);
    }
}
