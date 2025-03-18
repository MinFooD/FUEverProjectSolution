using AutoMapper;
using BusinessLogicLayer.Dtos.ApplicationUsersDtos;
using BusinessLogicLayer.Dtos.PetDtos;
using BusinessLogicLayer.ServiceContracts;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using DataAccessLayer.RepositoryContracts;

namespace BusinessLogicLayer.Services;

public class ApplicationUsersService(IApplicationUsersRepository repository, IMapper mapper) : IApplicationUsersService
{
    private readonly IApplicationUsersRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<ApplicationUsersResponse?> GetPetOwnerByIdAsync(Guid id)
    {
        ApplicationUser? applicationUser = await _repository.GetPetOwnerByIdAsync(id);

        if (applicationUser == null) 
            return null;

        ApplicationUsersResponse applicationUsersResponse = _mapper.Map<ApplicationUsersResponse>(applicationUser);

        return applicationUsersResponse;
    }

    public async Task<ApplicationUsersResponse?> UpdateApplicationUsers(ApplicationUsersUpdateRequest applicationUsersUpdateRequest)
    {
        if (applicationUsersUpdateRequest is null)
            return null;

        ApplicationUser application = _mapper.Map<ApplicationUser>(applicationUsersUpdateRequest);

        ApplicationUser? applicationUser = await _repository.UpdateApplicationUsers(application);

        ApplicationUsersResponse applicationUsersResponse = _mapper.Map<ApplicationUsersResponse>(application);

        return applicationUsersResponse;
    }
}
