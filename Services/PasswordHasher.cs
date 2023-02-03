using System.Security.Cryptography;
using System.Text;
using Libreforum.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;

namespace Libreforum.Services;

public class PasswordHasher<TUser> : IPasswordHasher<TUser>
    where TUser : User
{
    public string HashPassword(TUser user, string password)
    {
        byte[] saltBytes = Encoding.UTF8.GetBytes(user.Salt);
        return Convert.ToBase64String(
            KeyDerivation.Pbkdf2(
                password: password!,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 69420,
                numBytesRequested: 256 / 4
            )
        );
    }

    public PasswordVerificationResult VerifyHashedPassword(
        TUser user,
        string hashedPassword,
        string rawPassword
    ) =>
        HashPassword(user, rawPassword) == hashedPassword
            ? PasswordVerificationResult.Success
            : PasswordVerificationResult.Failed;
}
