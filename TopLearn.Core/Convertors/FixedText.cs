namespace TopLearn.Core.Convertors;
public class FixedText
{
    public static string FixedEmail(string email) =>
        email.Trim().ToLower();

}
