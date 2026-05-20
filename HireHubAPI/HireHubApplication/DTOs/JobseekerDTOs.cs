namespace HireHubApplication.DTOs
{
    public class CreateSeekerProfileDto
    {
        public string FullName { get; set; }
        public string Skills { get; set; }
        public int ExperienceYears { get; set; }
    }

    public class ApplyJobDto
    {
        public string CoverLetter { get; set; }
    }
}
