using HireHubDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HireHubInfrastructure.Data
{
    public class HireHubDBContext : DbContext
    {
        public HireHubDBContext(DbContextOptions<HireHubDBContext> options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobApplication> JobApplication { get; set; }
        public DbSet<SeekerProfile> SeekerProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ── User ────────────────────────────────────────────────────
            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(u => u.Id);
                e.HasIndex(u => u.Email).IsUnique();
                e.Property(u => u.Email).IsRequired().HasMaxLength(200);
                e.Property(u => u.PasswordHash).IsRequired();
                e.Property(u => u.Role).HasConversion<string>();
            });

            // ── Company ─────────────────────────────────────────────────
            modelBuilder.Entity<Company>(e =>
            {
                e.HasKey(c => c.Id);
                e.Property(c => c.Name).IsRequired().HasMaxLength(200);

                e.HasOne(c => c.User)
                 .WithOne(u => u.Company)
                 .HasForeignKey<Company>(c => c.UserId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            // ── Job ─────────────────────────────────────────────────────
            modelBuilder.Entity<Job>(e =>
            {
                e.HasKey(j => j.Id);
                e.Property(j => j.Title).IsRequired().HasMaxLength(200);
                e.Property(j => j.Location).IsRequired().HasMaxLength(200);
                e.Property(j => j.JobType).HasConversion<string>();
                e.Property(j => j.SalaryMin).HasColumnType("decimal(18,2)");
                e.Property(j => j.SalaryMax).HasColumnType("decimal(18,2)");

                e.HasOne(j => j.Company)
                 .WithMany(c => c.Jobs)
                 .HasForeignKey(j => j.CompanyId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            // ── SeekerProfile ───────────────────────────────────────────
            modelBuilder.Entity<SeekerProfile>(e =>
            {
                e.HasKey(s => s.Id);
                e.Property(s => s.FullName).IsRequired().HasMaxLength(200);

                e.HasOne(s => s.User)
                 .WithOne(u => u.SeekerProfile)
                 .HasForeignKey<SeekerProfile>(s => s.UserId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            // ── JobApplication ──────────────────────────────────────────
            modelBuilder.Entity<JobApplication>(e =>
            {
                e.HasKey(a => a.Id);
                e.Property(a => a.Status).HasConversion<string>();

                e.HasIndex(a => new { a.JobId, a.SeekerId }).IsUnique();

                e.HasOne(a => a.Job)
                 .WithMany(j => j.Applications)
                 .HasForeignKey(a => a.JobId)
                 .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(a => a.Seeker)
                 .WithMany(s => s.Applications)
                 .HasForeignKey(a => a.SeekerId)
                 .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
