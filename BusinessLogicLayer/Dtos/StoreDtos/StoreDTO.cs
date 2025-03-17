namespace BusinessLogicLayer.Dtos.StoreDtos;

public class StoreDTO
{
    public Guid StoreID { get; set; }
    public string StoreName { get; set; }
    public string Address { get; set; }
    public string Image { get; set; }
    public string HotLine { get; set; }
    public string Email { get; set; }
    public string Policy { get; set; }  
    public string BusinessLicience { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public Guid OwnerID { get; set; }  
}