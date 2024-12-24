using TopLearn.Core.Convertors;
using TopLearn.Core.DTOs.Account;
using TopLearn.Core.Generator;
using TopLearn.Core.Security;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Context;
using TopLearn.DataLayer.Entities.Users;

namespace TopLearn.Core.Services.Implement;
public class UserService(TopLearnContext context) : IUserServices
{
    public bool ActiveAccount(string activeCode)
    {
        var user = context.Users.SingleOrDefault(a => a.ActiveCode == activeCode);
        if (user == null || user.IsActive)
            return false;

        user.IsActive = true;
        user.ActiveCode = GuidGenerator.GenerateUniqueId();
        context.SaveChanges();
        return true;
    }

    public int AddUser(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
        return user.Id;
    }

    public void DeleteUser(int userId)
    {
        var user = GetUserById(userId);
        user.IsDelete = true;
        UpdateUser(user);
    }

    public User GetUserByActiveCode(string activeCode)
    {
        return context.Users.SingleOrDefault(a => a.ActiveCode == activeCode);
    }

    public User GetUserByEmail(string email)
    {
        return context.Users.SingleOrDefault(a => a.Email == email);
    }

    public User GetUserById(int userId)
    {
        return context.Users.Find(userId);
    }

    public User GetUserByUsername(string username)
    {
        return context.Users.SingleOrDefault(a => a.Username == username);
    }

    public int GetUserIdByUsername(string username)
    {
        return context.Users.SingleOrDefault(a => a.Username == username).Id;
    }

    public bool IsExistEmail(string email) =>
        context.Users.Any(u => u.Email == email);

    public bool IsExistUsername(string userName) =>
        context.Users.Any(s => s.Username == userName);

    public User LoginUser(LoginViewModel login)
    {
        string email = FixedText.FixedEmail(login.Email);
        var user = context.Users
            .SingleOrDefault(a => a.Email == email);
        if (user != null)
        {
            if (PasswordHelper.ComparePassword(login.Password, user.Password))
                return user;
        }
        return null;
    }

    public void UpdateUser(User user)
    {
        context.Users.Update(user);
        context.SaveChanges();
    }
}
