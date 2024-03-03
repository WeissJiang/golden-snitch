using System.ComponentModel.DataAnnotations;

namespace golden_snitch.Entities.Projects
{
    public class Project : GenericRecord
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
