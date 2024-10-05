using TopLearn.Core.DTOs.UserPanel;
using TopLearn.Core.Services.Interfaces;

namespace TopLearn.Core.Services.Implement;
public class UserPanelServices(IUserService userService) : IUserPanelServices
{
    public InformationUserViewModel GetUserInformation(string username)
    {
        var user = userService.GetUserByUsername(username);
        InformationUserViewModel information = new();
        information.Username = user.Username;
        information.Email = user.Email;
        information.RegisterDate = user.RegisterDate;
        information.Wallet = 0;

        return information;
    }
}
