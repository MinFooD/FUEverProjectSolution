namespace BusinessLogicLayer.Dtos.PetDtos;

public class PetAddRequest
{
    public string PetName { get; set; } = string.Empty;
    public string Breed { get; set; } = string.Empty;
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
