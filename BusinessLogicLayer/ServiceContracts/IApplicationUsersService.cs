using BusinessLogicLayer.Dtos.ApplicationUsersDtos;

namespace BusinessLogicLayer.ServiceContracts;

public interface IApplicationUsersService
{
    Task<ApplicationUsersResponse?> GetPetOwnerByIdAsync(Guid id);

    Task<ApplicationUsersResponse?> UpdateApplicationUsers(ApplicationUsersUpdateRequest applicationUsersUpdateRequest);
}
