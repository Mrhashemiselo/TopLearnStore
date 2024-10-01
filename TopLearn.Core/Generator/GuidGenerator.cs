namespace TopLearn.Core.Generator;
public class GuidGenerator
{
    public static string GenerateActiveCode() =>
        Guid.NewGuid().ToString().Replace("-", "");
}
