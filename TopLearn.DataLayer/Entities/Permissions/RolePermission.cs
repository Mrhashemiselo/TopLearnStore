using System.ComponentModel.DataAnnotations.Schema;
using TopLearn.DataLayer.Entities.Users;

namespace TopLearn.DataLayer.Entities.Permissions;
public class RolePermission
{
    public int Id { get; set; }
    public int RoleId { get; set; }
    public int PermissionId { get; set; }

    [ForeignKey("RoleId")]
    public Role Role { get; set; }

    [ForeignKey("PermissionId")]
    public Permission Permission { get; set; }
}
