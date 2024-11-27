using Microsoft.AspNetCore.Http;
using TopLearn.Core.Generator;

namespace TopLearn.Core.Images;
public class AvatarHelper
{
    public static string SaveAvatar(IFormFile userAvatar)
    {
        if (userAvatar == null)
            return null;

        var avatarFileName = GuidGenerator.GenerateUniqueId() + Path.GetExtension(userAvatar.FileName);
        var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", avatarFileName);
        using (var stream = new FileStream(imagePath, FileMode.Create))
        {
            userAvatar.CopyTo(stream);
        }
        return avatarFileName;
    }
}
