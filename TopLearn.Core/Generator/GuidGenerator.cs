namespace TopLearn.Core.Generator;
public class GuidGenerator
{
    public static string GenerateUniqId() =>
        Guid.NewGuid().ToString().Replace("-", "");
}
