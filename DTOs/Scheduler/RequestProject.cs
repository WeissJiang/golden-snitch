using System.Text.Json.Serialization;

namespace golden_snitch.DTOs.Scheduler
{
    public class RequestProject
    {
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("description")] public string? Description { get; set; }
    }
}
