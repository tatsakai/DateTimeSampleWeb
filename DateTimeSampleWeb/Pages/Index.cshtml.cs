using DateTimeSampleWeb.libraries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Encodings.Web;

namespace DateTimeSampleWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;



        }

        public void OnGet()
        {
            ViewData["DateTime"] = DateTimeEX.UtcNow();

        }
    }
}
