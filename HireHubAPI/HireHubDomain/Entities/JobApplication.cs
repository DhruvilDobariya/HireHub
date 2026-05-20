using System.Text.Json.Serialization;

namespace HireHubDomain.Entities
{
    public class JobApplication
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public int SeekerId { get; set; }
        public string? CoverLetter { get; set; }
        public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;
        public DateTime AppliedAt { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        public Job? Job { get; set; }
        [JsonIgnore]
        public SeekerProfile? Seeker { get; set; }
    }
}
