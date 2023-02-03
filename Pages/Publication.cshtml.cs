using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Libreforum.Pages
{
    public class Publication : PageModel
    {
        private readonly ILogger<Publication> _logger;

        public Publication(ILogger<Publication> logger)
        {
            _logger = logger;
        }

        public void OnGet(int publicationID = 0) { }
    }
}
