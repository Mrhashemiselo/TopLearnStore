using System.ComponentModel.DataAnnotations;

namespace TopLearn.Core.DTOs;
public class RegisterViewModel
{
    [Display(Name = "نام کاربری")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(100, ErrorMessage = "{0} نباید از {1} بزرگتر باشد")]
    [MinLength(4, ErrorMessage = "{0} نباید از {1} کوچکتر باشد")]
    public string UserName { get; set; }

    [Display(Name = "پست الکترونیک")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
    [MaxLength(150, ErrorMessage = "{0} نباید از {1} بزرگتر باشد")]
    public string Email { get; set; }

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
