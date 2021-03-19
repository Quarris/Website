using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebsiteRework.Pages {
    public class CommissionsModel : PageModel {
        private readonly ILogger<CommissionsModel> _logger;

        public CommissionsModel(ILogger<CommissionsModel> logger) {
            this._logger = logger;
        }

        public void OnGet() {
        }
    }
}