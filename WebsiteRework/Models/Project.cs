using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebsiteRework.Models {
    public class Project {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public Link[] Links { get; set; }

        public override string ToString() {
            return JsonSerializer.Serialize(this);
        }
    }

    public class Link {
        public string Name { get; set; }
        [JsonPropertyName("link")] public string Ref { get; set; }

        public override string ToString() {
            return JsonSerializer.Serialize(this);
        }
    }
}