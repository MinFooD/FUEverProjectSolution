using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    [StringLength(200)]
    public string ProfileImage { get; set; }
    public DateTime DateOfBirth { get; set; }

    [StringLength(255)]
    public string Address { get; set; }

    public DateTime RegistrationDate { get; set; }

    [StringLength(20)]
    public string Status { get; set; } 
    public Guid? StoreId { get; set; }
}