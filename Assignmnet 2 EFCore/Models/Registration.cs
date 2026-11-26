

namespace Assignmnet_2_EFCore.Models;

public class Registration
{
    public int AttendeeId { get; set; }
    public Attendee Attendee { get; set; } = null!;

    public int EventId { get; set; }
    public Event Event { get; set; } = null!;

    public string? Note { get; set; }

    public DateTime RegistrationDate { get; set; }
}
