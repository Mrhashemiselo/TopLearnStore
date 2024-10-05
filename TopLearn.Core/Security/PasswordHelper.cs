using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace TopLearn.Core.Security;
public class PasswordHelper
{
    public static string EncodingPassword(string password) //Encrypt using MD5
    {
        // Generate a random salt
        byte[] salt = new byte[16];
        using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
        {
            rng.GetBytes(salt);
        }

        // Hash the password with the salt
        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 32));

        // Combine salt and hashed password for storage
        return Convert.ToBase64String(salt) + ":" + hashed;
    }

    public static bool VerifyPassword(string inputPassword, string storedHash)
    {
        // Split the stored hash into salt and hash
        var parts = storedHash.Split(':');
        var salt = Convert.FromBase64String(parts[0]);
        var hash = parts[1];

        // Hash the input password with the same salt
        string inputHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: inputPassword,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 32));

        // Compare the hashes
        return inputHash == hash;
    }

}
