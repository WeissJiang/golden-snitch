﻿using golden_snitch.Entities.Tickets;
using System.Text.Json.Serialization;

namespace golden_snitch.Entities.Scheduler
{
    public class TaskTag : GenericRecord
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = "#1c83a5";
        [JsonIgnore] public virtual List<Task> Tasks { get; set; }
    }
}
