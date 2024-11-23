using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TopLearn.Core.Convertors;
using TopLearn.Core.DTOs.Account;
using TopLearn.Core.Generator;
using TopLearn.Core.Security;
using TopLearn.Core.Senders;
using TopLearn.Core.Services.Interfaces;

namespace TopLearn.Web.Controllers;
public class AccountController(IUserServices userService,
    IViewRenderService viewRenderService) : Controller
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
        if (userService.IsExistUsername(model.Username))
        {
            ModelState.AddModelError("Username", "نام کاربری معتبر نیست");
            return View(model);
        }
        if (userService.IsExistEmail(FixedText.FixedEmail(model.Email)))
        {
            ModelState.AddModelError("Email", "ایمیل معتبر نیست");
            return View(model);
        }

        DataLayer.Entities.Users.User user = new()
        {
            ActiveCode = GuidGenerator.GenerateUniqueId(),
            Avatar = "DefaultAvatar.jpg",
            IsActive = false,
            Password = PasswordHelper.EncodingPassword(model.Password),
            Email = FixedText.FixedEmail(model.Email),
            RegisterDate = DateTime.Now,
            Username = model.Username
        };
        userService.AddUser(user);

        #region SendAvticationEmail

        string body = viewRenderService.RenderToStringAsync("_ActiveEmail", user);
        SendEmail.Send(user.Email, "فعالسازی", body);
        #endregion

        return View("SuccessRegister", user);
    }
    #endregion

    #region Login
    [Route("Login")]
    public IActionResult Login(bool EditProfile = false)
    {
        ViewBag.EditProfile = EditProfile;
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
                List<Claim> claims = new()
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.Username)
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = model.RememberMe
                };
                HttpContext.SignInAsync(principal, properties);

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

    #region Logout
    [Route("Logout")]
    public IActionResult Logout()
    {
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Redirect("/");
    }
    #endregion

    #region Active Account
    public IActionResult ActiveAccount(string id)
    {
        ViewBag.IsActice = userService.ActiveAccount(id);
        return View();
    }
    #endregion

    #region Forgot Password
    [Route("ForgotPassword")]
    public ActionResult ForgotPassword()
    {
        return View();
    }

    [HttpPost]
    [Route("ForgotPassword")]
    public ActionResult ForgotPassword(ForgotPasswordViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        string fixedEmail = FixedText.FixedEmail(model.Email);
        var user = userService.GetUserByEmail(fixedEmail);

        if (user == null)
        {
            ModelState.AddModelError("Email", "کاربری یافت نشد");
            return View(model);
        }

        string bodyEmail = viewRenderService.RenderToStringAsync("_ForgotPassword", user);
        SendEmail.Send(user.Email, "بازیابی کلمه عبور", bodyEmail);
        ViewBag.IsSuccess = true;

        return View();
    }
    #endregion

    #region Reset Password
    public ActionResult ResetPassword(string id)
    {
        return View(new ResetPasswordViewModel()
        {
            ActiveCode = id
        });
    }

    [HttpPost]
    public ActionResult ResetPassword(ResetPasswordViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = userService.GetUserByActiveCode(model.ActiveCode);

        if (user == null)
            return NotFound();

        string hashNewPassword = PasswordHelper.EncodingPassword(user.Password);
        user.Password = hashNewPassword;
        userService.UpdateUser(user);
        ViewBag.IsSuccess = true;
        return Redirect("/login");
    }
    #endregion
}

