using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TopLearn.Core.DTOs.UserPanel;
using TopLearn.Core.Services.Interfaces;

namespace TopLearn.Web.Areas.UserPanel.Controllers;
[Area("UserPanel")]
[Authorize]
public class HomeController(IUserPanelServices userPanelServices) : Controller
{
    public IActionResult Index()
    {
        return View(userPanelServices.GetUserInformation(User.Identity.Name));
    }

    #region Edit Profile
    [Route("UserPanel/EditProfile")]
    public IActionResult EditProfile()
    {
        return View(userPanelServices.GetDataForEditProfileUser(User.Identity.Name));
    }

    [Route("UserPanel/EditProfile")]
    [HttpPost]
    public IActionResult EditProfile(EditProfileViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        userPanelServices.EditProfile(User.Identity.Name, model);
        ViewBag.IsSuccess = true;

        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Redirect("/Login?EditProfile=true");
    }
    #endregion

    #region Change Password
    [Route("UserPanel/ChangePassword")]
    public IActionResult ChangePassword()
    {
        return View();
    }

    [HttpPost]
    [Route("UserPanel/ChangePassword")]
    public IActionResult ChangePassword(ChangePasswordViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var currentUsername = User.Identity.Name;
        if (!userPanelServices.CompareOldPassword(currentUsername, model.OldPassword))
        {
            ModelState.AddModelError("OldPassword", "کلمه عبور فعلی صحیح نمی باشد");
            return View(model);
        }

        userPanelServices.ChangeUserPassword(currentUsername, model.Password);
        ViewBag.IsSuccess = true;

        return View();
    }
    #endregion
}
