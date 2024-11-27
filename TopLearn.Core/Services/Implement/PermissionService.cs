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
                RoleId = roleId,
                UserId = userId
            });
        }
        context.SaveChanges();
    }

    public void EditRoleUser(int userId, List<int> rolesId)
    {
        context.UserRoles
            .Where(w => w.UserId == userId)
            .ToList()
            .ForEach(f => context.UserRoles.Remove(f));

        AddRolesToUser(rolesId, userId);
    }

    public List<Role> GetRoles()
    {
        return context.Roles.ToList();
    }
}
