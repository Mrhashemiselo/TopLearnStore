using Microsoft.AspNetCore.Mvc;
using TopLearn.Core.Convertors;
using TopLearn.Core.DTOs.Account;
using TopLearn.Core.Generator;
using TopLearn.Core.Security;
using TopLearn.Core.Services.Interfaces;

namespace TopLearn.Web.Controllers;
public class AccountController(IUserService userService) : Controller
{
    #region Register
    [Route("Register")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [Route("Register")]
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

        DataLayer.Entities.Users.User user = new()
        {
            ActiveCode = GuidGenerator.GenerateActiveCode(),
            Avatar = "DefaultAvatar.jpg",
            IsActive = false,
            Password = PasswordHelper.EncodingPassword(model.Password),
            Email = FixedText.FixedEmail(model.Email),
            RegisterDate = DateTime.Now,
            UserName = model.UserName
        };
        userService.AddUser(user);

        // TODO: send activation email

        return View("SuccessRegister", user);
    }
    #endregion

    #region Login
    [Route("Login")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [Route("Login")]
    public IActionResult Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        var user = userService.LoginUser(model);
        if (user != null)
        {
            if (user.IsActive)
            {
                // TODO: login user
                ViewBag.IsSuccess = true;
                return View();
            }
            else
            {
                ModelState.AddModelError("Email", "حساب کاربری شما فعال نیست");
            }

        }
        ModelState.AddModelError("Email", "کاربری یافت نشد");
        return View();
    }
    #endregion

    #region ActiveAccount
    public IActionResult ActiveAccount(string id)
    {
        ViewBag.IsActice = userService.ActiveAccount(id);
        return View();
    }
    #endregion
}

