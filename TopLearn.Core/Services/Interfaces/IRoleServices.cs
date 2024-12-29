using TopLearn.DataLayer.Entities.Users;

namespace TopLearn.Core.Services.Interfaces;
public interface IRoleServices
{
    List<Role> GetRoles();
    int AddRole(Role role);
    void AddRolesToUser(List<int> roleIds, int userId);
    void EditRoleUser(int userId, List<int> rolesId);
    Role GetRoleById(int roleId);
    void UpdateRole(Role role);
    void DeleteRole(Role role);
}
