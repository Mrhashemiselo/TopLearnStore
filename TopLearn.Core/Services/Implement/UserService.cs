using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Context;

namespace TopLearn.Core.Services.Implement;
public class UserService(TopLearnContext context) : IUserService
{
    public bool IsExistEmail(string email) =>
        context.Users.Any(u => u.Email == email);

    public bool IsExistUserName(string userName) =>
        context.Users.Any(s => s.UserName == userName);
}
