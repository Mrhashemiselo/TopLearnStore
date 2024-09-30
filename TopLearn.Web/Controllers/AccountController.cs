using Microsoft.AspNetCore.Mvc;
using TopLearn.Core.Convertors;
using TopLearn.Core.DTOs;
using TopLearn.Core.Services.Interfaces;

namespace TopLearn.Web.Controllers;
public class AccountController(IUserService userService) : Controller
{
    [Route("Register")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        if (userService.IsExistUserName(model.UserName))
        {
            ModelState.AddModelError("UserName", "نام کاربری معتبر نیست");
            return View(model);
        }
        if (userService.IsExistEmail(FixedText.FixedEmail(model.Email)))
        {
            ModelState.AddModelError("Email", "پست الکترونیکی معتبر نیست");
            return View(model);
        }

        // TODO : Register User
        return View(model);
    }
}

