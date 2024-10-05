using System.ComponentModel.DataAnnotations;

namespace TopLearn.Core.DTOs.Account;
public class ForgotPasswordViewModel
{
    [Display(Name = "پست الکترونیک")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نیست")]
    public string Email { get; set; }
}
