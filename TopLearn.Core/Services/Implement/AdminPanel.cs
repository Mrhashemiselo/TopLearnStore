using TopLearn.Core.DTOs.Users;
using TopLearn.Core.Generator;
using TopLearn.Core.Security;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Context;
using TopLearn.DataLayer.Entities.Users;

namespace TopLearn.Core.Services.Implement;
public class AdminPanel(TopLearnContext context,
    IUserServices userServices) : IAdminPanel
{
    public int AddUserFromAdmin(CreateUserViewModel model)
    {
        var user = new User();
        user.Password = PasswordHelper.EncodingPassword(model.Password);
        user.ActiveCode = GuidGenerator.GenerateUniqueId();
        user.Email = model.Email;
        user.IsActive = true;
        user.RegisterDate = DateTime.Now;
        user.Username = model.Username;

        #region SaveAvatar
        if (model.UserAvatar != null)
        {
            string imagePath = "";
            user.Avatar = GuidGenerator.GenerateUniqueId() + Path.GetExtension(model.UserAvatar.FileName);
            imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", user.Avatar);
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                model.UserAvatar.CopyTo(stream);
            }
        }
        #endregion
        return userServices.AddUser(user);
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
