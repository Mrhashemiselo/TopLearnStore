using TopLearn.Core.DTOs.Account;
using TopLearn.DataLayer.Entities.Users;

namespace TopLearn.Core.Services.Interfaces;
public interface IUserService
{
    bool IsExistUserName(string userName);
    bool IsExistEmail(string email);
    int AddUser(User user);
    User LoginUser(LoginViewModel login);
    bool ActiveAccount(string activeCode);
}
