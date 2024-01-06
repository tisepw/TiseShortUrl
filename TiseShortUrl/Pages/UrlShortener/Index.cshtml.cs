using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TiseShortUrl.Models;

namespace TiseShortUrl.Pages.UrlShortener
{
    public class IndexModel : PageModel
    {
        private readonly TiseShortUrl.Data.TiseShortUrlContext _context;

        public IndexModel(TiseShortUrl.Data.TiseShortUrlContext context)
        {
            _context = context;
        }

        public IList<ShortUrl> ShortUrl { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ShortUrl = await _context.ShortUrl.ToListAsync();
        }
    }
}
