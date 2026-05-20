namespace HireHubDomain.Entities
{
    public enum UserRole
    {
        JobSeeker,
        Employer,
        Admin
    }

    public enum ApplicationStatus
    {
        Pending,
        Reviewed,
        Shortlisted,
        Rejected,
        Hired
    }

    public enum JobType
    {
        FullTime,
        PartTime,
        Contract,
        Internship,
        Remote
    }

    public enum JobStatus
    {
        Draft,
        Active,
        Closed,
        PendingApproval,
        Rejected
    }

    public enum ExperienceLevel
    {
        Entry,
        Mid,
        Senior,
        Lead,
        Executive
    }
}
