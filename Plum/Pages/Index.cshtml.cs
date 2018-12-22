﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Plum.Pages
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToPage("/Libraries/Index");
            }

            return Page();
        }
    }
}