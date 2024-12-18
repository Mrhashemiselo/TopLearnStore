﻿using TopLearn.DataLayer.Entities.Users;

namespace TopLearn.Core.Services.Interfaces;
public interface IPermissionService
{
    #region Roles
    List<Role> GetRoles();
    void AddRolesToUser(List<int> roleIds, int userId);
    void EditRoleUser(int userId, List<int> rolesId);
    #endregion
}
