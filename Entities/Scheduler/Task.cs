using golden_snitch.Entities.Projects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace golden_snitch.Entities.Scheduler
{
    public class Task : GenericRecord
    {
        [Required] public string Name { get; set; }
        public string Comment { get; set; } = string.Empty;
        [Column(TypeName = "datetime")]  public DateTime? StartDate { get; set; } = DateTime.UtcNow;
        [Column(TypeName = "datetime")]  public DateTime? EndDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "varchar(7)")] public string? WorkDays { get; set; }

        [Required] public int ProjectId { get; set; }
        [ForeignKey("ProjectId")] public virtual Project Project { get; set; }

        [Required] public int TaskTagId { get; set; }
        [ForeignKey("TaskTagId")] public virtual TaskTag Tasktag { get; set; }
    }
}
