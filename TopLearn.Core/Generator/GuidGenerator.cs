namespace TopLearn.Core.Generator;
public class GuidGenerator
{
    public static string GenerateUniqueId() =>
        Guid.NewGuid().ToString().Replace("-", "");
}
