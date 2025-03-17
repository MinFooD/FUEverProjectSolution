using AutoMapper;
using BusinessLogicLayer.Dtos.PetDtos;
using BusinessLogicLayer.ServiceContracts;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryContracts;

namespace BusinessLogicLayer.Services;

public class PetsService(IPetsRepository petsRepository, IApplicationUsersRepository applicationUsers, IMapper mapper) : IPetsService
{
    private readonly IPetsRepository _petsRepository = petsRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IApplicationUsersRepository _applicationUsers = applicationUsers;

    public async Task<PetResponse?> AddPet(PetAddRequest petAddRequest)
    {
        petAddRequest.PetOwnerID = Guid.Parse("fdb1c124-5416-4ce2-9f11-4af81d4963b8");
        Pet petInput = _mapper.Map<Pet>(petAddRequest); 
        
        ApplicationUser? applicationUser = await _applicationUsers.GetPetOwnerByIdAsync(petInput.PetOwnerID);

        if (applicationUser == null)
            return null;

        petInput.PetOwner = applicationUser;

        Pet? addedPet = await _petsRepository.AddPet(petInput);

        if (addedPet == null)
        {
            return null;
        }

        PetResponse addedPetResponse = _mapper.Map<PetResponse>(addedPet);

        return addedPetResponse;
    }

    public async Task<IEnumerable<PetResponse?>> GetPets()
    {
        IEnumerable<Pet?> pets = await _petsRepository.GetPets();

        IEnumerable<PetResponse?> petResponses = _mapper.Map<IEnumerable<PetResponse>>(pets);

        return petResponses;
    }
}