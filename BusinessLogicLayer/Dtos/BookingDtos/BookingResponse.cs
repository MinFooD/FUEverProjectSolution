namespace BusinessLogicLayer.Dtos.BookingDtos;

public class BookingResponse
{
    public Guid BookingID { get; set; }
    public Guid PetID { get; set; }
    public Guid StoreID { get; set; }
    public Guid ServiceID { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Status { get; set; } = default!;
    public decimal TotalPrice { get; set; }
    public decimal FinalPrice { get; set; }
    public string OrderRequest { get; set; } = default!;
}