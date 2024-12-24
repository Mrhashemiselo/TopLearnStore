using TopLearn.Core.DTOs.UserPanel;
using TopLearn.Core.Generator;
using TopLearn.Core.Images;
using TopLearn.Core.Security;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Context;

namespace TopLearn.Core.Services.Implement;
public class UserPanelServices(IUserServices userService,
    TopLearnContext context,
    IWalletServices walletServices) : IUserPanelServices
{
    public void ChangeUserPassword(string username, string newPassword)
    {
        var user = userService.GetUserByUsername(username);
        user.Password = PasswordHelper.EncodingPassword(newPassword);
        userService.UpdateUser(user);
    }

    public bool CompareOldPassword(string username, string oldPassword)
    {
        var hashedStoredPassword = userService.GetUserByUsername(username).Password;
        return PasswordHelper.ComparePassword(oldPassword, hashedStoredPassword);
    }

    public void EditProfile(string username, EditProfileViewModel model)
    {
        if (model.UserAvatar != null && AvatarHelper.IsImage(model.UserAvatar))
        {
            string imagePath = "";
            if (model.AvatarName != "DefaultAvatar.jpg")
            {
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", model.AvatarName);
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                }

            }
            model.AvatarName = GuidGenerator.GenerateUniqueId() + Path.GetExtension(model.UserAvatar.FileName);
            imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", model.AvatarName);
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                model.UserAvatar.CopyTo(stream);
            }
        }

        var user = userService.GetUserByUsername(username);
        user.Username = model.Username;
        user.Email = model.Email;
        user.Avatar = model.AvatarName;

        userService.UpdateUser(user);
    }

    public EditProfileViewModel GetDataForEditProfileUser(string username)
    {
        return context.Users
            .Where(a => a.Username == username)
            .Select(u => new EditProfileViewModel()
            {
                AvatarName = u.Avatar,
                Email = u.Email,
                Username = u.Username
            }).Single();
    }

    public SidebarViewModel GetSidebarUserPanelData(string username)
    {
        return context.Users
            .Where(u => u.Username == username)
            .Select(a => new SidebarViewModel()
            {
                Username = a.Username,
                ImageName = a.Avatar,
                RegisterDate = a.RegisterDate
            }).Single();
    }

    public InformationUserViewModel GetUserInformation(string username)
    {
        var user = userService.GetUserByUsername(username);
        InformationUserViewModel information = new();
        information.Username = user.Username;
        information.Email = user.Email;
        information.RegisterDate = user.RegisterDate;
        information.Wallet = walletServices.BalanceUserWallet(username);

        return information;
    }

    public InformationUserViewModel GetUserInformation(int userId)
    {
        var user = userService.GetUserById(userId);
        return new InformationUserViewModel()
        {
            Username = user.Username,
            Email = user.Email,
            RegisterDate = user.RegisterDate,
            Wallet = walletServices.BalanceUserWallet(user.Username)
        };
    }
}
