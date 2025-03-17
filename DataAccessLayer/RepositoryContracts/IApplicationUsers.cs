using DataAccessLayer.Entities;

namespace DataAccessLayer.RepositoryContracts;

public interface IApplicationUsers
{
    Task<ApplicationUser?> GetPetOwnerByIdAsync(Guid id);
}
