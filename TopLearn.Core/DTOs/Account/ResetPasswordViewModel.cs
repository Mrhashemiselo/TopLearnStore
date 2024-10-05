using System.ComponentModel.DataAnnotations;

namespace TopLearn.Core.DTOs.Account;
public class ResetPasswordViewModel
{
    public string ActiveCode { get; set; }

    [Display(Name = "کلمه عبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MinLength(8, ErrorMessage = "{0} نباید از {1} کوچکتر باشد")]
    public string Password { get; set; }

    [Display(Name = "تکرار کلمه عبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MinLength(8, ErrorMessage = "{0} نباید از {1} کوچکتر باشد")]
    [Compare("Password", ErrorMessage = "کلمه عبور و تکرار آن یکسان نیستند")]
    public string RePassword { get; set; }
}
