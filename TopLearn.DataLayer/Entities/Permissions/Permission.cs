using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TopLearn.DataLayer.Entities.Permissions;
public class Permission
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "عنوان نقش")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
    public string Title { get; set; }


    public int? ParentId { get; set; }

    [ForeignKey("ParentId")]
    public List<Permission> Permissions { get; set; }

    public List<RolePermission> RolePermissions { get; set; }
}
