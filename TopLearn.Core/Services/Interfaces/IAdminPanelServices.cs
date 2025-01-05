using TopLearn.Core.DTOs.AdminPanel;

namespace TopLearn.Core.Services.Interfaces;
public interface IAdminPanelServices
{
    UserForAdminViewModel GetUsers(int pageId = 1, string filterEmail = "", string filterUsername = "");
    UserForAdminViewModel GetDeletedUsers(int pageId = 1, string filterEmail = "", string filterUsername = "");
    int AddUserFromAdmin(CreateUserViewModel model);
    EditUserViewModel GetUserForShowInEditMode(int userId);
    void EditUserFromAdmin(EditUserViewModel editUserViewModel);
}
