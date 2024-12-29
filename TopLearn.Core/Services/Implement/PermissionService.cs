using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Context;
using TopLearn.DataLayer.Entities.Permissions;

namespace TopLearn.Core.Services.Implement;
public class PermissionService(TopLearnContext context) : IPermissionService
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
}
