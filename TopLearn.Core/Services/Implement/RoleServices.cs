using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Context;
using TopLearn.DataLayer.Entities.Users;

namespace TopLearn.Core.Services.Implement;
public class RoleServices(TopLearnContext context) : IRoleServices
{
    public int AddRole(Role role)
    {
        context.Roles.Add(role);
        context.SaveChanges();
        return role.Id;
    }

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

    public void DeleteRole(Role role)
    {
        role.IsDelete = true;
        UpdateRole(role);
    }

    public void EditRoleUser(int userId, List<int> rolesId)
    {
        context.UserRoles
            .Where(w => w.UserId == userId)
            .ToList()
            .ForEach(f => context.UserRoles.Remove(f));

        AddRolesToUser(rolesId, userId);
    }

    public Role GetRoleById(int roleId) =>
        context.Roles.Find(roleId);

    public List<Role> GetRoles() =>
        context.Roles.ToList();

    public void UpdateRole(Role role)
    {
        context.Roles.Update(role);
        context.SaveChanges();
    }
}
