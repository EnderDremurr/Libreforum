using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Libreforum.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Libreforum.Models;

[PrimaryKey(nameof(Id))]
[Microsoft.EntityFrameworkCore.Index(nameof(Login), IsUnique = true)]
public class User : IdentityUser
{
    public string DisplayName { get; set; }
    public string? Signature { get; set; }

    [Key]
    public string Login { get; set; }
    public string Salt { get; set; }
    public int Reputation { get; set; }

    public DateTime RegistrationDate { get; set; }

    public User(
        string displayName,
        string email,
        string login,
        string salt,
        string passwordHash,
        DateTime registrationDate
    )
    {
        DisplayName = displayName;
        Email = email;
        Signature = null;
        Login = login;
        Salt = salt;
        PasswordHash = passwordHash;
        Reputation = 0;
        RegistrationDate = registrationDate; }
}
