using golden_snitch.Entities.Users;
using System.Text.Json.Serialization;
using static golden_snitch.Entities.Users.User;

namespace golden_snitch.DTOs.Tenants
{
    public class ResponseUser
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("email")] public string Email { get; set; }
        [JsonPropertyName("adminLevel")] public User.UserPrivilegeLevel PrivilegeLevel { get; set; }

        public ResponseUser(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            PrivilegeLevel = user.PrivilegeLevel;
        }
    }
}
