using System.Data;
using System.Text.Json.Serialization;
using TaskApi.Enums;

namespace TaskApi.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Role Role { get; set; } = Role.User;

        //Navigation property
        [JsonIgnore]
        public List<Tasks>? Tasks { get; set; } = new List<Tasks>();

    }
}
