using System.ComponentModel.DataAnnotations;

namespace TopLearn.DataLayer.Entities.Users;
public class UserRole
{
    public UserRole()
    {

    }

    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }

    #region Relations
    public virtual User User { get; set; }
    public virtual Role Role { get; set; }
    #endregion
}
