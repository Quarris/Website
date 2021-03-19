using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace WebsiteRework.Services {
    public class JsonFileGreetingService {
        public JsonFileGreetingService(IWebHostEnvironment webHostEnvironment) {
            this.WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName => Path.Combine(this.WebHostEnvironment.WebRootPath, "data", "greetings.json");

        public string GetRandomGreeting(Random random) {
            using (StreamReader jsonFileReader = File.OpenText(this.JsonFileName)) {
                string[] greetings = JsonSerializer.Deserialize<string[]>(jsonFileReader.ReadToEnd());
                return greetings[random.Next(0, greetings.Length)];
            }
        }

        public IEnumerable<string> GetGreetings() {
            using (StreamReader jsonFileReader = File.OpenText(this.JsonFileName)) {
                return JsonSerializer.Deserialize<string[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
    }
}
