using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Libreforum.Pages
{
    public class Profile : PageModel
    {
        private readonly ILogger<Profile> _logger;

        public Profile(ILogger<Profile> logger)
        {
            _logger = logger;
        }

        public void OnGet(string userLogin = "admin") { }
    }
}
