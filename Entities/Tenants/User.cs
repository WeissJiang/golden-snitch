using golden_snitch.Entities.Tenants;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [MaxLength(30)]
        public string Name { get; set; }

        [Unicode(false)]
        public string Email { get; set; }

        public UserPrivilegeLevel PrivilegeLevel { get; set; }
        
        public virtual List<ClaimSet> ClaimSets { get; set; } = new();
    }
}
