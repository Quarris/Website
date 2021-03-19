
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using WebsiteRework.Models;

namespace WebsiteRework.Services {
    public class JsonFileProjectService {
        public JsonFileProjectService(IWebHostEnvironment webHostEnvironment) {
            this.WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName => Path.Combine(this.WebHostEnvironment.WebRootPath, "data", "projects.json");

        public IEnumerable<ProjectCategory> GetCategories() {
            using (var jsonFileReader = File.OpenText(this.JsonFileName)) {
                var json = JsonDocument.Parse(jsonFileReader.ReadToEnd());
                foreach (var property in json.RootElement.EnumerateObject()) {
                    Project[] projects = GetProjects(property.Value.EnumerateArray()).ToArray();
                    yield return new ProjectCategory {
                        Name = property.Name,
                        Projects = projects
                    };
                }
            }
        }

        private IEnumerable<Project> GetProjects(JsonElement.ArrayEnumerator arrayEnumerator) {
            foreach (var element in arrayEnumerator) {
                yield return GetProject(element.GetString());
            }
        }

        private Project GetProject(string project) {
            string projectJson = Path.Combine(this.WebHostEnvironment.WebRootPath, "data", "projects", project + ".json");
            using (var reader = File.OpenText(projectJson)) {
                return JsonSerializer.Deserialize<Project>(reader.ReadToEnd(),
                    new JsonSerializerOptions {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
    }
}