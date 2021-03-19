using System.Text.Json;

namespace WebsiteRework.Models {
    public class ProjectCategory {
        public string Name { get; set; }
        public Project[] Projects { get; set; }

        public override string ToString() {
            return JsonSerializer.Serialize(this);
        }
    }
}