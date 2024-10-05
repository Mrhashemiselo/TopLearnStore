using System.ComponentModel.DataAnnotations;

namespace TopLearn.DataLayer.Entities.Users;
public class User
{
    public User()
    {

    }

    [Key]
    public int Id { get; set; }

    [Display(Name = "نام کاربری")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(100, ErrorMessage = "تعداد حروف {0} نباید از {1} بزرگتر باشد")]
    [MinLength(4, ErrorMessage = "تعداد حروف {0} نباید از {1} کوچکتر باشد")]
    public string Username { get; set; }

    [Display(Name = "پست الکترونیک")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
    [MaxLength(150, ErrorMessage = "تعداد حروف {0} نباید از {1} بزرگتر باشد")]
    public string Email { get; set; }

    [Display(Name = "کلمه عبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MinLength(8, ErrorMessage = "تعداد حروف {0} نباید از {1} کوچکتر باشد")]
    public string Password { get; set; }

    [Display(Name = "کد فعال سازی")]
    [MaxLength(50, ErrorMessage = "تعداد حروف {0} نباید از {1} بزرگتر باشد")]
    public string ActiveCode { get; set; }

    [Display(Name = "وضعیت")]
    public bool IsActive { get; set; }

    [Display(Name = "آواتار")]
    [MaxLength(150)] //for database
    public string Avatar { get; set; }

    [Display(Name = "تاریخ ثبت نام")]
    public DateTime RegisterDate { get; set; }

    #region Relations
    public virtual List<UserRole> UserRoles { get; set; }
    #endregion
}
