using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Context;
using TopLearn.DataLayer.Entities.Permissions;

namespace TopLearn.Core.Services.Implement;
public class PermissionServices(TopLearnContext context) : IPermissionServices
{
    public List<Permission> GetAllPermission() =>
        context.Permission.ToList();

    public void AddPermissionsToRole(int roleId, List<int> permissions)
    {
        foreach (var permission in permissions)
        {
            context.RolePermission.Add(new RolePermission()
            {
                PermissionId = permission,
                RoleId = roleId
            });
        }
        context.SaveChanges();
    }

    public List<int> PermissionsRole(int roleId) =>
        context.RolePermission
        .Where(w => w.RoleId == roleId)
        .Select(s => s.PermissionId)
        .ToList();

    public void UpdatePermissionsRole(int roleId, List<int> permissions)
    {
        context.RolePermission
            .Where(w => w.RoleId == roleId)
            .ToList()
            .ForEach(f => context.RolePermission.Remove(f));

        AddPermissionsToRole(roleId, permissions);
    }

    public bool CheckPermission(int permissionId, string username)
    {
        var userId = context.Users
            .First(f => f.Username == username).Id;
        var userRoles = context.UserRoles
            .Where(a => a.UserId == userId)
            .Select(s => s.RoleId)
            .ToList();

        if (!userRoles.Any())
            return false;

        var rolesPermission = context.RolePermission
            .Where(w => w.PermissionId == permissionId)
            .Select(s => s.RoleId)
            .ToList();

        return rolesPermission
            .Any(w => userRoles.Contains(w));
    }
}
