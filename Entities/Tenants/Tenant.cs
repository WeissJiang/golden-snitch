using System.ComponentModel.DataAnnotations;

namespace golden_snitch.Entities.Users
{
    public class Tenant : GenericRecord
    {
        [Key] public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
