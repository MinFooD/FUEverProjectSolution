namespace BusinessLogicLayer.Dtos.ApplicationUsersDtos;

public class ApplicationUsersUpdateRequest
{
    public Guid PetOwnerID { get; set; }

    public string UserName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }

    public string? ProfileImage { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string? Address { get; set; }
}
