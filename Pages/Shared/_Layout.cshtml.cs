using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Libreforum.Pages.Shared
{
    public class _Layout : PageModel
    {
        private readonly ILogger<_Layout> _logger;

        public _Layout(ILogger<_Layout> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var session = HttpContext.Request.HttpContext.Session;
        }

        public void OnPost()
        {
            var context = HttpContext.Request.HttpContext;
            context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
