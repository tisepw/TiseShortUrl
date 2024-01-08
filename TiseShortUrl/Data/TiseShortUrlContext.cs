using Microsoft.EntityFrameworkCore;

namespace TiseShortUrl.Data
{
    public class TiseShortUrlContext : DbContext
    {
        public TiseShortUrlContext (DbContextOptions<TiseShortUrlContext> options)
            : base(options)
        {
        }

        public DbSet<TiseShortUrl.Models.ShortUrl> ShortUrl { get; set; } = default!;
    }
}
