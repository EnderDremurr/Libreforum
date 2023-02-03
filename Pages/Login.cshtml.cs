using System.Security.Claims;
using Libreforum.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Libreforum.Pages
{
    public class Login : PageModel
    {
        private readonly UserManager _userManager;

        public Login(UserManager userManager)
        {
            _userManager = userManager;
        }

        public void OnPost(string login = " ", string password = " ")
        {
            var user = _userManager.AuthenticateUser(login, password);
            var context = HttpContext.Request.HttpContext;
            var session = context.Session;

            if (user == null)
            {
                Console.WriteLine("User not found");
                return;
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim("DisplayName", user.DisplayName),
                new Claim(ClaimTypes.Role, "Administrator"),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            context.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity)
            );
            
            session.SetInt32("UserId", 0);
            session.SetString("DisplayName", user.DisplayName);

            Console.WriteLine("Successfully authenticated user");
        }
    }
}
