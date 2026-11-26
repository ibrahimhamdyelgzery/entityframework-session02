
using System.ComponentModel.DataAnnotations;

namespace Assignmnet_2_EFCore.Models;

public class Organizer
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = null!;

    [MaxLength(150)]
    public string? CompanyName { get; set; }

    [Required]
    public bool IsVerified { get; set; }

    public OrganizerProfile? Profile { get; set; }

    public ICollection<Event> Events { get; set; } = new List<Event>();
}
