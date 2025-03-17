using System.ComponentModel.DataAnnotations;

namespace FUEverProject.ViewModels;

public class RegisterRequestViewModel
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Gmail { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public int Roles { get; set; }
    [StringLength(50)]
    public string UserName { get; set; }

    [StringLength(10)]
    public string Phone { get; set; }

    public DateTime DateOfBirth { get; set; }

    [StringLength(255)]
    public string Address { get; set; }
}