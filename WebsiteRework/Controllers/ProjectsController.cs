using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebsiteRework.Models;
using WebsiteRework.Services;

namespace WebsiteRework.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase {

        public ProjectsController(JsonFileProjectService projectService) {
            this.ProjectService = projectService;
        }

        public JsonFileProjectService ProjectService { get; }

        [HttpGet]
        public IEnumerable<Project> Get() {
            return this.ProjectService.GetAllProjects();
        }
    }
}