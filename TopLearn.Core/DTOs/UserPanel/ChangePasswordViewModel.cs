using System.ComponentModel.DataAnnotations;

namespace TopLearn.Core.DTOs.UserPanel;
public class ChangePasswordViewModel
{
    [Display(Name = "کلمه عبور فعلی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string OldPassword { get; set; }

    [Display(Name = "کلمه عبور جدید")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MinLength(8, ErrorMessage = "{0} نباید از {1} حرف کوچکتر باشد")]
    public string Password { get; set; }

    [Display(Name = "تکرار کلمه عبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MinLength(8, ErrorMessage = "{0} نباید از {1} حرف کوچکتر باشد")]
    [Compare("Password", ErrorMessage = "کلمه عبور و تکرار آن یکسان نیستند")]
    public string RePassword { get; set; }
}
