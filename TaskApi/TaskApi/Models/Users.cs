using System.Text.Json.Serialization;

namespace TaskApi.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //Navigation property
        [JsonIgnore]
        public List<Tasks>? Tasks { get; set; } = new List<Tasks>();

    }
}
