using Microsoft.EntityFrameworkCore;
using TopLearn.Core.DTOs.AdminPanel;
using TopLearn.Core.Generator;
using TopLearn.Core.Images;
using TopLearn.Core.Security;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Context;
using TopLearn.DataLayer.Entities.Users;

namespace TopLearn.Core.Services.Implement;
public class AdminPanelServices(TopLearnContext context,
    IUserServices userServices) : IAdminPanelServices
{
    public int AddUserFromAdmin(CreateUserViewModel model)
    {
        if (!AvatarHelper.IsImage(model.UserAvatar))
            return -1;
        User user = new()
        {
            Password = PasswordHelper.EncodingPassword(model.Password),
            ActiveCode = GuidGenerator.GenerateUniqueId(),
            Email = model.Email,
            IsActive = true,
            RegisterDate = DateTime.Now,
            Username = model.Username
        };

        #region SaveAvatar
        if (model.UserAvatar != null)
        {
            user.Avatar = AvatarHelper.SaveAvatar(model.UserAvatar);
        }
        #endregion
        return userServices.AddUser(user);
    }

    public void EditUserFromAdmin(EditUserViewModel editUserViewModel)
    {
        var user = userServices.GetUserById(editUserViewModel.UserId);
        user.Email = editUserViewModel.Email;
        if (!string.IsNullOrEmpty(editUserViewModel.Password))
        {
            user.Password = PasswordHelper.EncodingPassword(editUserViewModel.Password);
        }
        if (editUserViewModel.UserAvatar != null && AvatarHelper.IsImage(editUserViewModel.UserAvatar))
        {
            if (editUserViewModel.AvatarName != "DefaultAvatar.jpg")
            {
                var deletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", editUserViewModel.AvatarName);
                if (File.Exists(deletePath))
                    File.Delete(deletePath);
            }
            user.Avatar = AvatarHelper.SaveAvatar(editUserViewModel.UserAvatar);
        }
        context.Users.Update(user);
        context.SaveChanges();
    }

    public UserForAdminViewModel GetDeletedUsers(int pageId = 1, string filterEmail = "", string filterUsername = "")
    {
        var result = context.Users
            .AsQueryable()
            .IgnoreQueryFilters()
            .Where(w => w.IsDelete);

        if (!string.IsNullOrEmpty(filterEmail))
            result = result.Where(w => w.Email.Contains(filterEmail));
        if (!string.IsNullOrEmpty(filterUsername))
            result = result.Where(a => a.Username.Contains(filterUsername));

        int take = 10;
        int skip = (pageId - 1) * take;

        return new UserForAdminViewModel()
        {
            CurrentPage = pageId,
            PageCount = result.Count() / take,
            Users = result
                          .OrderBy(u => u.RegisterDate)
                          .Skip(skip)
                          .Take(take)
                          .ToList()
        };
    }

    public EditUserViewModel GetUserForShowInEditMode(int userId)
    {
        return context.Users.Where(u => u.Id == userId)
            .Select(s => new EditUserViewModel()
            {
                UserId = s.Id,
                AvatarName = s.Avatar,
                Email = s.Email,
                Username = s.Username,
                UserRoles = s.UserRoles.Select(r => r.RoleId).ToList()
            }).Single();
    }

    public UserForAdminViewModel GetUsers(int pageId = 1, string filterEmail = "", string filterUsername = "")
    {
        var result = context.Users.AsQueryable();

        if (!string.IsNullOrEmpty(filterEmail))
            result = result.Where(w => w.Email.Contains(filterEmail));
        if (!string.IsNullOrEmpty(filterUsername))
            result = result.Where(a => a.Username.Contains(filterUsername));

        int take = 10;
        int skip = (pageId - 1) * take;

        return new UserForAdminViewModel()
        {
            CurrentPage = pageId,
            PageCount = result.Count() / take,
            Users = result
                          .OrderBy(u => u.RegisterDate)
                          .Skip(skip)
                          .Take(take)
                          .ToList()
        };
    }
}
