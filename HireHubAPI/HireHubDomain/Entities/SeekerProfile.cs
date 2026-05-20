namespace HireHubDomain.Entities
{
    public class SeekerProfile
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Skills { get; set; }
        public int ExperienceYears { get; set; }
        public string ResumeUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public User User { get; set; }
        public ICollection<JobApplication> Applications { get; set; }
    }
}
