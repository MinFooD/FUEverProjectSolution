using DataAccessLayer.Entities;

namespace DataAccessLayer.RepositoryContracts;

public interface IProductRepository
{
    Task<List<Product>> GetAllProductAsync(Guid? storeId);
	Task<Product> CreateAsync(Product product);

	Task<Product?> UpdateAsync(Guid id, Product product);

	Task<Product?> DeleteAsync(Guid id);
}