using DataAccessLayer.Entities.EntityEnums;

namespace BusinessLogicLayer.Dtos.PetDtos;

public class PetUpdateRequest
{
    public Guid PetID { get; set; }
    public string PetName { get; set; } = default!;
    public string Breed { get; set; } = default!;
    public int Age { get; set; }
    public string? SpecialPathology { get; set; }
    public decimal Weight { get; set; }
    public string? Diet { get; set; }
    public bool Gender { get; set; }
    public string? Habit { get; set; }
    public string? OtherRequest { get; set; }
    public string? HealthDetail { get; set; }
    public string? Image { get; set; }
    public Guid PetOwnerID { get; set; }
}
