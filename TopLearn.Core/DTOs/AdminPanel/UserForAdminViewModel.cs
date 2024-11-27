using TopLearn.DataLayer.Entities.Users;

namespace TopLearn.Core.DTOs.AdminPanel;
public class UserForAdminViewModel
{
    public List<User> Users { get; set; }
    public int CurrentPage { get; set; }
    public int PageCount { get; set; }
}
