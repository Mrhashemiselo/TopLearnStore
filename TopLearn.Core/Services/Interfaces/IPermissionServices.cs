using TopLearn.DataLayer.Entities.Permissions;

namespace TopLearn.Core.Services.Interfaces;
public interface IPermissionServices
{
    List<Permission> GetAllPermission();
    void AddPermissionsToRole(int roleId, List<int> permissions);
    List<int> PermissionsRole(int roleId);
    void UpdatePermissionsRole(int roleId, List<int> permissions);
    bool CheckPermission(int permissionId, string username);
}
