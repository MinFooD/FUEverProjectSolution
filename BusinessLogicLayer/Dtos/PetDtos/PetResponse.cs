using DataAccessLayer.Entities.EntityEnums;

namespace BusinessLogicLayer.Dtos.PetDtos;

public class PetResponse
{
    public Guid PetID { get; set; }
    public string PetName { get; set; } = string.Empty;
    public string Breed { get; set; } = string.Empty;
    public int Age { get; set; }
    public string? SpecialPathology { get; set; }
    public decimal Weight { get; set; }
    public string? Diet { get; set; }
    public string Gender { get; set; } = default!;
    public string? Habit { get; set; }
    public string? OtherRequest { get; set; }
    public string? HealthDetail { get; set; }
    public string? Image { get; set; }
    public string? PetOwnerName { get; set; } 
    public int BookingCount { get; set; }
}