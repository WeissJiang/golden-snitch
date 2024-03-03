using golden_snitch.Entities.Tenants;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace golden_snitch.Entities.Users
{
    public class User : GenericRecord
    {
        public enum UserPrivilegeLevel
        {
            Standard,
            Manager,
            Admin,
            Super
        }

        [Key] public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [Unicode(false)]
        public string Email { get; set; }

        public UserPrivilegeLevel PrivilegeLevel { get; set; }
        
        public virtual List<ClaimSet> ClaimSets { get; set; } = new();
    }
}
