using Assignmnet_2_EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Assignmnet_2_EFCore.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(e => e.Description)
            .IsRequired();

        builder.Property(e => e.StartDate)
            .IsRequired();

        builder.Property(e => e.MaxAttendees)
            .IsRequired();

        builder.HasOne(e => e.Organizer)
            .WithMany(o => o.Events)
            .HasForeignKey(e => e.OrganizerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ParentEvent)
            .WithMany(e => e.Sessions)
            .HasForeignKey(e => e.ParentEventId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property<DateTime>("CreatedAt")
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property<DateTime?>("ModifiedAt");
    }
}
