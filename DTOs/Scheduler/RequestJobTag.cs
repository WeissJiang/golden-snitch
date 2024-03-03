using System.Text.Json.Serialization;

namespace golden_snitch.DTOs.Scheduler
{
    public class RequestJobTag
    {
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("color")] public string Color { get; set; }
    }
}
