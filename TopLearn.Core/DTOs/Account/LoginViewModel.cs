using System.ComponentModel.DataAnnotations;

namespace TopLearn.Core.DTOs.Account;
public class LoginViewModel
{
    [Display(Name = "پست الکترونیک")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
    public string Email { get; set; }

    [Display(Name = "کلمه عبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string Password { get; set; }

    [Display(Name = "مرا به خاطر بسپار")]
    public bool RememberMe { get; set; }
}
