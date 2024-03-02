using System.ComponentModel.DataAnnotations;

namespace golden_snitch.Entities.Projects
{
    public class Project : GenericRecord
    {
        [Required] public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
