using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.DTOs.Users;
using TopLearn.Core.Services.Interfaces;

namespace TopLearn.Web.Pages.Admin.Users;

public class IndexModel(IAdminPanel adminPanel) : PageModel
{
    public UserForAdminViewModel UserForAdminViewModel { get; set; }

    public void OnGet(int pageId = 1, string filterUsername = "", string filterEmail = "")
    {
        UserForAdminViewModel = adminPanel.GetUsers(pageId, filterEmail, filterUsername);
    }
}
