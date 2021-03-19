using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebsiteRework.Pages {
    public class AboutModel : PageModel {
        private readonly DateTime _birthday = new DateTime(1997, 12, 2);
        private readonly ILogger<AboutModel> _logger;
        public int Age;

        public AboutModel(ILogger<AboutModel> logger) {
            this._logger = logger;
        }

        public void OnGet() {
            this.Age = (int) Math.Floor(DateTime.Now.Subtract(this._birthday).TotalDays / 365.25);
        }
    }
}