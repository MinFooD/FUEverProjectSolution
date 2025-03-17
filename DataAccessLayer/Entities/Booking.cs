namespace DataAccessLayer.Entities;

public class Booking
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
    public virtual Pet Pet { get; set; } = default!;
    public virtual Store Store { get; set; } = default!;
    public virtual Service Service { get; set; } = default!;
    public virtual ICollection<ChatMessage> ChatMessages { get; set; } = [];
    public virtual ICollection<StepsTracking> StepsTrackings { get; set; } = [];
    public virtual ICollection<Feedback> Feedbacks { get; set; } = [];
    public virtual ICollection<Transaction> Transactions { get; set; } = [];
}