

using Microsoft.EntityFrameworkCore;

namespace Assignmnet_2_EFCore.Models;

[Owned]
public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }
}