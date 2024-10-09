﻿using TopLearn.Core.DTOs.UserPanel;

namespace TopLearn.Core.Services.Interfaces;
public interface IUserPanelServices
{
    InformationUserViewModel GetUserInformation(string username);
    SidebarViewModel GetSidebarUserPanelData(string username);
    EditProfileViewModel GetDataForEditProfileUser(string username);
    void EditProfile(string username, EditProfileViewModel model);
    bool CompareOldPassword(string username, string oldPassword);
}
