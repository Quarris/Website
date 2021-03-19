using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebsiteRework.Services;

namespace WebsiteRework.Pages {
    public class IndexModel : PageModel {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileGreetingService GreetingService;
        public string Greeting { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, JsonFileGreetingService greetingService) {
            this._logger = logger;
            this.GreetingService = greetingService;
        }

        public void OnGet() {
            this.Greeting = this.GreetingService.GetRandomGreeting(new System.Random());
        }
    }
}