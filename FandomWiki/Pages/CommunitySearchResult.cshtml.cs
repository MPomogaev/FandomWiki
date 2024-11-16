using FandomWiki.Database;
using FandomWiki.Pages.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FandomWiki.Pages {
    public class CommunitySearchResultModel: PageModel {
        ILogger<CommunitySearchResultModel> _logger;
        CommunityRepository _repository;

        [BindProperty]
        public string SearchLine { get; set; }
        [BindProperty(SupportsGet = true)]
        public List<Community> Communities { get; set; }

        public CommunitySearchResultModel(ILogger<CommunitySearchResultModel> logger, CommunityRepository repository) {
            _logger = logger;
            _repository = repository;
        }

        public void OnGet() {
        }

        public void OnPost() {
            _logger?.LogInformation("searching for communities with name like " + SearchLine);
            Communities = _repository.Search(SearchLine).ToList();
        }
    }
}
