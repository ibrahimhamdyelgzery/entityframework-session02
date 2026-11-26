
using Assignmnet_2_EFCore.Configurations;
using Assignmnet_2_EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Assignmnet_2_EFCore.Data;

public class EventHubContext : DbContext
{
    public DbSet<Organizer> Organizers { get; set; }
    public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Attendee> Attendees { get; set; }
    public DbSet<Badge> Badges { get; set; }
    public DbSet<Registration> Registrations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=KARIMGODA;Database=EventHubDb;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<OrganizerProfile>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Bio)
                .HasMaxLength(1000);

            entity.Property(p => p.WebsiteUrl)
                .HasMaxLength(300);

            entity.Property(p => p.LogoUrl)
                .HasMaxLength(300);

            entity.HasOne(p => p.Organizer)
                .WithOne(o => o.Profile)
                .HasForeignKey<OrganizerProfile>(p => p.OrganizerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Badge>(entity =>
        {
            entity.HasKey(b => b.Id);

            entity.Property(b => b.BadgeNumber)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasIndex(b => b.BadgeNumber)
                .IsUnique();

            entity.Property(b => b.IssueDate)
                .IsRequired();

            entity.Property(b => b.Tier)
                .IsRequired()
                .HasConversion<string>();

            entity.HasOne(b => b.Attendee)
                .WithOne(a => a.Badge)
                .HasForeignKey<Badge>(b => b.AttendeeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.ApplyConfiguration(new EventConfiguration());
        modelBuilder.ApplyConfiguration(new RegistrationConfiguration());
    }
}