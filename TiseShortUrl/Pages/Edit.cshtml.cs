using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TiseShortUrl.Data;
using TiseShortUrl.Models;

namespace TiseShortUrl.Pages
{
    public class EditModel : PageModel
    {
        private readonly TiseShortUrl.Data.TiseShortUrlContext _context;

        public EditModel(TiseShortUrl.Data.TiseShortUrlContext context)
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

            var shorturl =  await _context.ShortUrl.FirstOrDefaultAsync(m => m.Id == id);
            if (shorturl == null)
            {
                return NotFound();
            }
            ShortUrl = shorturl;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ShortUrl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShortUrlExists(ShortUrl.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ShortUrlExists(long id)
        {
            return _context.ShortUrl.Any(e => e.Id == id);
        }
    }
}
