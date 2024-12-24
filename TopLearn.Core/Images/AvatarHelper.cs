using Microsoft.AspNetCore.Http;
using TopLearn.Core.Generator;

namespace TopLearn.Core.Images;
public static class AvatarHelper
{
    public static HashSet<string> imageExtensions = new(StringComparer.OrdinalIgnoreCase)
    {
        ".tiff",
        ".jpg",
        ".jpeg",
        ".gif",
        ".png"
    };

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

    public static bool IsImage(IFormFile userAvatar)
    {
        var extensionFile = (Path.GetExtension(userAvatar.FileName)).ToLower();
        return imageExtensions.Contains(extensionFile);
    }

}
