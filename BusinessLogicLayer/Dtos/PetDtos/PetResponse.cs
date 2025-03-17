using BusinessLogicLayer.Dtos.BookingDtos;

namespace BusinessLogicLayer.Dtos.PetDtos;

public class PetResponse
{
    public string PetName { get; set; } = default!;

    public string Breed { get; set; } = default!;

    public int Age { get; set; }

    public string SpecialPathology { get; set; } = default!;

    public decimal Weight { get; set; }

    public string Diet { get; set; } = default!;

    public bool Gender { get; set; }

    public string Habit { get; set; } = default!;

    public string OtherRequest { get; set; } = default!;

    public string HealthDetail { get; set; } = default!;

    public string Image { get; set; } = default!;

    public IEnumerable<BookingResponse> bookingResponses { get; set; } = [];
}