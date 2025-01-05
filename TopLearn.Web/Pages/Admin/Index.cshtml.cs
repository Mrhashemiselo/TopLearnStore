using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.Security;

namespace TopLearn.Web.Pages.Admin;

[PermissionChecker(1)]
public class IndexModel : PageModel
{
    public void OnGet()
    {
    }
}
