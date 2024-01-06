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
    public class DetailsModel : PageModel
    {
        private readonly TiseShortUrl.Data.TiseShortUrlContext _context;

        public DetailsModel(TiseShortUrl.Data.TiseShortUrlContext context)
        {
            _context = context;
        }

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
    }
}
