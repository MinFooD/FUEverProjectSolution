using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public string? ProfileImage { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string? Address { get; set; }

    public DateTime RegistrationDate { get; set; }

    public string Status { get; set; } = "Active";

    public Guid? StoreId { get; set; }
}