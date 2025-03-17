using DataAccessLayer.Entities;

namespace DataAccessLayer.RepositoryContracts;

public interface ICategoryRepository
{
    Task<List<Category>> GetCategoryAsync();
}