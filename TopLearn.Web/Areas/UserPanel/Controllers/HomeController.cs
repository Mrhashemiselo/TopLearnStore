using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TopLearn.Core.Services.Interfaces;

namespace TopLearn.Web.Areas.UserPanel.Controllers;
[Area("UserPanel")]
[Route("UserPanel")]
[Authorize]
public class HomeController(IUserPanelServices userPanelServices) : Controller
{
    public IActionResult Index()
    {
        return View(userPanelServices.GetUserInformation(User.Identity.Name));
    }
}
