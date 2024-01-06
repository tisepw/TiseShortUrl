using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace TiseShortUrl.Pages
{
    public class FaqModel : PageModel
    {
        private readonly ILogger<FaqModel> _logger;

        public FaqModel(ILogger<FaqModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
			string dateTime = DateTime.Now.ToString("d", new CultureInfo("en-US"));
			ViewData["TimeStamp"] = dateTime;
		}
    }
}
