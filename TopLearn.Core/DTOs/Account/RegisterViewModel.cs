using System.ComponentModel.DataAnnotations;

namespace TopLearn.Core.DTOs.Account;
public class RegisterViewModel
{
    [Display(Name = "نام کاربری")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(100, ErrorMessage = "{0} نباید از {1} حرف بزرگتر باشد")]
    [MinLength(4, ErrorMessage = "{0} نباید از {1} حرف کوچکتر باشد")]
    public string Username { get; set; }

    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
    [MaxLength(150, ErrorMessage = "{0} نباید از {1} حرف بزرگتر باشد")]
    public string Email { get; set; }

    [Display(Name = "کلمه عبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MinLength(8, ErrorMessage = "{0} نباید از {1} حرف کوچکتر باشد")]
    public string Password { get; set; }

    [Display(Name = "تکرار کلمه عبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MinLength(8, ErrorMessage = "{0} نباید از {1} حرف کوچکتر باشد")]
    [Compare("Password", ErrorMessage = "کلمه عبور و تکرار آن یکسان نیستند")]
    public string RePassword { get; set; }
}
