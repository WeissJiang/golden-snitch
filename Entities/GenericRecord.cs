using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace golden_snitch.Entities
{
    public abstract class GenericRecord
    {
        public int Id { get; set; }
        [Column(TypeName = "datetime")] public DateTime CreationDateUTC { get; set; } = DateTime.UtcNow;
        [Column(TypeName = "datetime")] public DateTime LastModifiedDateUTC { get; set; } = DateTime.UtcNow;
        [StringLength(100)] public string TimeZone { get; set; }
    }
}
