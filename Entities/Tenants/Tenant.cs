using System.ComponentModel.DataAnnotations;

namespace golden_snitch.Entities.Users
{
    public class Tenant : GenericRecord
    {
        [MaxLength(30)]
        public string Name { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
