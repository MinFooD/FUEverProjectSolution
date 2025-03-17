using DataAccessLayer.Entities;

namespace DataAccessLayer.RepositoryContracts;

public interface IStoreRepository
{
    Task<List<Store>> GetStoreAsync(Guid? ownerId);
}