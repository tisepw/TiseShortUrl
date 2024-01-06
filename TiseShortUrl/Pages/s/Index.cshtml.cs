using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TiseShortUrl.Models;

namespace TiseShortUrl.Pages.s
{
    public class IndexModel : PageModel
    {
        private readonly TiseShortUrl.Data.TiseShortUrlContext _context;

        public IndexModel(TiseShortUrl.Data.TiseShortUrlContext context)
        {
            _context = context;
        }

        public string OriginalUrl { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string? shortUrl)
		{
			if (shortUrl == null)
			{
				return NotFound();
			}

            var selected = _context.ShortUrl.ToListAsync().Result.Find(x => x.Url == shortUrl);

            if (selected == null)
            {
                return NotFound();
            }

            ViewData["OriginalUrl"] = selected.OriginalUrl;
			OriginalUrl = selected.OriginalUrl;

			return Page();
		}
	}
}
