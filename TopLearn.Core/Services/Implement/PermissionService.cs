using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Context;
using TopLearn.DataLayer.Entities.Users;

namespace TopLearn.Core.Services.Implement;
public class PermissionService(TopLearnContext context) : IPermissionService
{
    public void AddRolesToUser(List<int> roleIds, int userId)
    {
        foreach (var roleId in roleIds)
        {
            context.UserRoles.Add(new UserRole()
            {
                Id = roleId,
                UserId = userId
            });
        }
        context.SaveChanges();
    }

    public List<Role> GetRoles()
    {
        return context.Roles.ToList();
    }
}
