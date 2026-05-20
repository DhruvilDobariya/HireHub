namespace HireHubDomain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public SeekerProfile SeekerProfile { get; set; }
        public Company Company { get; set; }
    }
}
