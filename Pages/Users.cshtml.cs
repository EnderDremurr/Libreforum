using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libreforum.Data;
using Libreforum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Libreforum.Pages
{
    [Authorize]
    public class Users : PageModel
    {
        private readonly DatabaseContext _databaseContext;
        public List<User> UserList { get; private set; } = new();

        public Users(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void OnGet()
        {
            UserList = _databaseContext.Users.ToList();
        }
    }
}
