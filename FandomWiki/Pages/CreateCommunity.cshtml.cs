using FandomWiki.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FandomWiki.Pages {
    public class CreateCommunityModel: PageModel {
        ILogger<CreateCommunityModel> _logger;
        CommunityRepository _repository;

        public CreateCommunityModel(ILogger<CreateCommunityModel> logger, CommunityRepository repository) {
            _logger = logger;
            _repository = repository;
        }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Description { get; set; }

        public void OnGet() {}

        public IActionResult OnPost() {
            if (!ModelState.IsValid) {
                return Page();
            }
            Community newCommunity = new() { Name = Name, Description = Description };
            _repository.Add(newCommunity);
            _logger.LogInformation("created new community, id = " + newCommunity.Id);
            return RedirectToPage("Index");
        }
    }
}
