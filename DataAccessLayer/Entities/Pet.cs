
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities;

public class Pet
{
    public Guid PetID { get; set; }

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

    public Guid PetOwnerID { get; set; }

	[ForeignKey("PetOwnerID")]
	public virtual ApplicationUser PetOwner { get; set; }

	public List<Booking> Bookings { get; set; } = [];
}