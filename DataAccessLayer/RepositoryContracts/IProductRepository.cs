using DataAccessLayer.Entities;

namespace DataAccessLayer.RepositoryContracts;

public interface IProductRepository
{
    Task<List<Product>> GetAllProductAsync(Guid? storeId);
}