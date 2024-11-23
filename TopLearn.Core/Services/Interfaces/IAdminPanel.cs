using TopLearn.Core.DTOs.Users;

namespace TopLearn.Core.Services.Interfaces;
public interface IAdminPanel
{
    UserForAdminViewModel GetUsers(int pageId = 1, string filterEmail = "", string filterUsername = "");
    int AddUserFromAdmin(CreateUserViewModel model);
}
