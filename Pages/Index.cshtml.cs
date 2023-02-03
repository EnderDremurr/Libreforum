using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Libreforum.Pages;

public class IndexModel : PageModel
{
    public string? Auth { get; private set; }

    public void OnGet()
    {
        var context = HttpContext.Request.HttpContext;
        var user = context.User.Identity;
        if (user is not null && user.IsAuthenticated)
        {
            Auth = $"User is authenticated. Auth type: {user.AuthenticationType}";
        }
        else
        {
            Auth = "User is not authenticated";
        }
    }
}
