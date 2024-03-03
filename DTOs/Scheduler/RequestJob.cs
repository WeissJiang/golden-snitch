using System.Text.Json.Serialization;

namespace golden_snitch.DTOs.Scheduler
{
    public class RequestJob
    {
        [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
        [JsonPropertyName("comment")] public string? Comment { get; set; }
        [JsonPropertyName("startDate")] public DateTime? StartDate { get; set; } = DateTime.UtcNow;
        [JsonPropertyName("endDate")] public DateTime? EndDate { get; set; } = DateTime.UtcNow;
        [JsonPropertyName("workDays")] public string WorkDays { get; set; }
        [JsonPropertyName("projectId")] public int ProjectId { get; set; }
        [JsonPropertyName("jobTagId")] public int JobTagId { get; set; }
    }
}
