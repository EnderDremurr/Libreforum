using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Libreforum.Pages
{
    public class Administration : PageModel
    {
        private readonly ILogger<Administration> _logger;

        public Administration(ILogger<Administration> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}