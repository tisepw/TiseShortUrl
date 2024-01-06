using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TiseShortUrl.Data;
using TiseShortUrl.Models;

namespace TiseShortUrl.Pages.UrlShortener
{
    public class DeleteModel : PageModel
    {
        private readonly TiseShortUrl.Data.TiseShortUrlContext _context;

        public DeleteModel(TiseShortUrl.Data.TiseShortUrlContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ShortUrl ShortUrl { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shorturl = await _context.ShortUrl.FirstOrDefaultAsync(m => m.Id == id);

            if (shorturl == null)
            {
                return NotFound();
            }
            else
            {
                ShortUrl = shorturl;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shorturl = await _context.ShortUrl.FindAsync(id);
            if (shorturl != null)
            {
                ShortUrl = shorturl;
                _context.ShortUrl.Remove(ShortUrl);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
