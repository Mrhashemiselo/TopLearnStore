using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace TopLearn.Core.DTOs.AdminPanel;
public class EditUserViewModel
{
    public EditUserViewModel()
    {
        UserRoles = new List<int>(); // Initialize the list
    }
    public int UserId { get; set; }

    public string? Username { get; set; }

    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
    [MaxLength(150, ErrorMessage = "{0} نباید از {1} حرف بزرگتر باشد")]
    public string Email { get; set; }

    [Display(Name = "کلمه عبور")]
    [MinLength(8, ErrorMessage = "{0} نباید از {1} حرف کوچکتر باشد")]
    public string? Password { get; set; }

    public IFormFile? UserAvatar { get; set; }

    public List<int> UserRoles { get; set; }

    public string? AvatarName { get; set; }
}
