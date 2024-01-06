using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TiseShortUrl.Models;

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
