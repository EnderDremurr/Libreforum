using Libreforum.Data;
using Libreforum.Models;
using Libreforum.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Libreforum.Pages
{
    public class Registration : PageModel
    {
        private readonly UserManager _userManager;

        public Registration(UserManager userManager)
        {
            _userManager = userManager;
        }

        public void OnPost(
            string login = "amongus",
            string displayName = "WhenTheImpostaIsSus",
            string password = "2281337",
            string email = "pizda@sus.amogus"
        )
        {
            var result = _userManager.RegisterUser(login, displayName, password, email);
            Console.WriteLine(result);
        }
    }
}
