using BusinessLogicLayer.Dtos.ProductDtos;

namespace BusinessLogicLayer.ServiceContracts;

public interface IProductService
{
    Task<List<ProductDTO>> GetAllProductAsync(Guid? storeId);
}