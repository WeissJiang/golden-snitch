using golden_snitch.Entities.Scheduler;
using System.Text.Json.Serialization;

namespace golden_snitch.DTOs.Scheduler
{
    public class ResponseJobTag
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("color")] public string Color { get; set; }
        [JsonPropertyName("tasks")] public IEnumerable<ResponseJob> Jobs { get; set; }

        ResponseJobTag(JobTag tt)
        {
            Id = tt.Id;
            Name = tt.Name;
            Color = tt.Color;
            Jobs = tt.Jobs.Select(t => new ResponseJob
            {
                Id = t.Id,
                Name = t.Name,
            });
        }

        public class ResponseJob
        {
            [JsonPropertyName("id")] public int Id { get; set; }

            [JsonPropertyName("name")] public string Name { get; set; }
        }
    }
}
