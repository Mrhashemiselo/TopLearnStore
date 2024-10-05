using TopLearn.Core.DTOs.UserPanel;

namespace TopLearn.Core.Services.Interfaces;
public interface IUserPanelServices
{
    InformationUserViewModel GetUserInformation(string username);
}
