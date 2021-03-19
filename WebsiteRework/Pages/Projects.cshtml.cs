using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebsiteRework.Models;
using WebsiteRework.Services;

namespace WebsiteRework.Pages {
    public class ProjectsModel : PageModel {
        private readonly ILogger<ProjectsModel> _logger;
        public JsonFileProjectService ProjectService;
        public IEnumerable<ProjectCategory> Categories { get; private set; }

        public ProjectsModel(ILogger<ProjectsModel> logger, JsonFileProjectService projectService) {
            this._logger = logger;
            this.ProjectService = projectService;
        }

        public void OnGet() {
            this.Categories = this.ProjectService.GetCategories();
        }
    }
}