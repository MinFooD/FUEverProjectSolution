namespace BusinessLogicLayer.Dtos.ProductDtos;

public class ProductDTO
{
    public Guid ProductID { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }

    public DateTime ManufacturingDate { get; set; }

    public DateTime ExpirationDate { get; set; }

    public int StockQuantity { get; set; }
    public string Size { get; set; }
    public string Image { get; set; }    
}