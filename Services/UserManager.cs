using System.Security.Cryptography;
using Libreforum.Data;
using Libreforum.Models;
using Microsoft.AspNetCore.Identity;

namespace Libreforum.Services;

public class UserManager
{
    private readonly DatabaseContext _databaseContext;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserManager(DatabaseContext databaseContext, IPasswordHasher<User> passwordHasher)
    {
        _databaseContext = databaseContext;
        _passwordHasher = passwordHasher;
    }

    public User? RegisterUser(
        string login = "sus",
        string displayName = "sus",
        string password = "sus",
        string email = "sus"
    )
    {
        User tempUser =
            new(
                displayName,
                email,
                login,
                Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                password,
                DateTime.Now
            );

        tempUser.PasswordHash = _passwordHasher.HashPassword(tempUser, password);

        var user = _databaseContext.Users.Add(tempUser).Entity;
        _databaseContext.SaveChanges();

        return user;
    }

    public User? AuthenticateUser(string login, string password)
    {
        var user = _databaseContext.Users.SingleOrDefault(user => user.Login == login);

        if (user != null)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if (result == PasswordVerificationResult.Success)
                return user;
        }

        return null;
    }

    public User? GetUserById(int id) => _databaseContext.Users.Find(id);

}