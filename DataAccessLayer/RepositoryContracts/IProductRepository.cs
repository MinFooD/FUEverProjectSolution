using DataAccessLayer.Entities;

namespace DataAccessLayer.RepositoryContracts;

public interface IProductRepository
{
    Task<List<Product>> GetAllProductAsync(Guid? storeId);
	Task<Product> CreateAsync(Product product);
}