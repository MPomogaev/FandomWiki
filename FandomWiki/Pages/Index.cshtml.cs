using FandomWiki.Database;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FandomWiki.Pages {
    public class IndexModel: PageModel {
        private readonly ILogger<IndexModel> _logger;
        private readonly DatabaseContext _context;

        public IndexModel(DatabaseContext context, ILogger<IndexModel> logger) {
            _logger = logger;
            _context = context;
        }

        public void OnGet() {

        }
    }
}
