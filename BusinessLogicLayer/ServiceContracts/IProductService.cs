using BusinessLogicLayer.Dtos.ProductDtos;

namespace BusinessLogicLayer.ServiceContracts;

public interface IProductService
{
    Task<List<ProductDTO>> GetAllProductAsync(Guid? storeId);

	Task<AddProductRequestDTO> CreateAsync(AddProductRequestDTO addProductRequestDTO);

	Task<UpdateProductRequestDTO> UpdateAsync(Guid id, UpdateProductRequestDTO updateProductRequestDTO);

	Task<ProductDTO?> DeleteAsync(Guid id);
}