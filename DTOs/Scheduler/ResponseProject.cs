using golden_snitch.Entities.Projects;
using golden_snitch.Entities.Scheduler;
using System.Text.Json.Serialization;

namespace golden_snitch.DTOs.Scheduler
{
    public class ResponseProject
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("description")] public string Description { get; set; }

        public ResponseProject(Project p)
        {
            Id = p.Id;
            Name = p.Name;
            Description = p.Description;
        }
    }
}
