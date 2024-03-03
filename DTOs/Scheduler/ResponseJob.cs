using Job = golden_snitch.Entities.Scheduler.Job;
using System.Text.Json.Serialization;

namespace golden_snitch.DTOs.Scheduler
{
    public class ResponseJob
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("comment")] public string? Comment { get; set; }
        [JsonPropertyName("startDate")] public DateTime? StartDate { get; set; }
        [JsonPropertyName("endDate")] public DateTime? EndDate { get; set; }
        [JsonPropertyName("workDays")] public string WorkDays { get; set; }
        [JsonPropertyName("projectId")] public int ProjectId { get; set; }
        [JsonPropertyName("jobTagId")] public int JobTagId { get; set; }

        public ResponseJob(Job j)
        {
            Id = j.Id;
            Name = j.Name;
            Comment = j.Comment;
            StartDate = j.StartDate;
            EndDate = j.EndDate;
            WorkDays = j.WorkDays;
            ProjectId = j.ProjectId;
            JobTagId = j.JobTagId;
        }
    }
}
