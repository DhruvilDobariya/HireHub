using System.Text.Json.Serialization;

namespace HireHubDomain.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string Location { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public User? User { get; set; }
        [JsonIgnore]
        public ICollection<Job>? Jobs { get; set; }
    }
}
