using TopLearn.Core.DTOs.Account;
using TopLearn.DataLayer.Entities.Users;

namespace TopLearn.Core.Services.Interfaces;
public interface IUserServices
{
    bool IsExistUsername(string userName);
    bool IsExistEmail(string email);
    int AddUser(User user);
    User LoginUser(LoginViewModel login);
    bool ActiveAccount(string activeCode);
    User GetUserByEmail(string email);
    User GetUserById(int userId);
    User GetUserByActiveCode(string activeCode);
    void UpdateUser(User user);
    User GetUserByUsername(string username);
    int GetUserIdByUsername(string username);
    void DeleteUser(int userId);
}
