using System.ComponentModel.DataAnnotations;
using TopLearn.DataLayer.Entities.Permissions;

namespace TopLearn.DataLayer.Entities.Users;
public class Role
{
    public Role()
    {
    }

    [Key]
    public int Id { get; set; }

    [Display(Name = "عنوان نقش")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(ErrorMessage = "مقدار {0} نباید از {1} بیشتر باشد")]
    public string Title { get; set; }

    public bool IsDelete { get; set; }

    #region Relations
    public virtual List<UserRole>? UserRoles { get; set; }
    public List<RolePermission>? RolePermissions { get; set; }
    #endregion
}
