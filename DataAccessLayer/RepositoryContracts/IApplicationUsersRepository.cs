using DataAccessLayer.Entities;

namespace DataAccessLayer.RepositoryContracts;

public interface IApplicationUsersRepository
{
    Task<ApplicationUser?> GetPetOwnerByIdAsync(Guid id);

    Task<ApplicationUser?> UpdateApplicationUsers(ApplicationUser applicationUser);
}
