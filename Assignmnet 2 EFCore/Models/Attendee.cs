
using System.ComponentModel.DataAnnotations;

namespace Assignmnet_2_EFCore.Models;

public class Attendee
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string FullName { get; set; } = null!;

    [Required]
    [EmailAddress]
    [MaxLength(200)]
    public string Email { get; set; } = null!;

    [Required]
    public Address Address { get; set; } = null!;

    public Badge? Badge { get; set; }

    public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
}
