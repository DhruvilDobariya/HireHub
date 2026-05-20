namespace HireHubDomain.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public required string Location { get; set; }
        public JobType JobType { get; set; }
        public decimal? SalaryMin { get; set; }
        public decimal? SalaryMax { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Company Company { get; set; }
        public ICollection<JobApplication> Applications { get; set; }
    }
}
