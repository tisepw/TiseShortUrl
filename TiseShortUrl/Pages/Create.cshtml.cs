using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TiseShortUrl.Data;
using TiseShortUrl.Models;

namespace TiseShortUrl.Pages
{
    public class CreateModel : PageModel
    {
        private readonly TiseShortUrl.Data.TiseShortUrlContext _context;

        public CreateModel(TiseShortUrl.Data.TiseShortUrlContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ShortUrl ShortUrl { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ShortUrl.Add(ShortUrl);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
