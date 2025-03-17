using System.ComponentModel.DataAnnotations;

namespace FUEverProject.ViewModels;

public class LoginRequestViewModel
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string UserName { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}