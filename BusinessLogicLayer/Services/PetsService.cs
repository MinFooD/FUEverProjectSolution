using AutoMapper;
using BusinessLogicLayer.Dtos.PetDtos;
using BusinessLogicLayer.ServiceContracts;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
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
        ApplicationUser? applicationUser = await _applicationUsers.GetPetOwnerByIdAsync(petAddRequest.PetOwnerID);

        if (applicationUser == null)
            return null;

        Pet petInput = _mapper.Map<Pet>(petAddRequest);

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

    public async Task<PetResponse?> UpdatePet(PetUpdateRequest petUpdateRequest)
    {
        petUpdateRequest.PetOwnerID = Guid.Parse("fdb1c124-5416-4ce2-9f11-4af81d4963b8");
        ApplicationUser? applicationUser = await _applicationUsers.GetPetOwnerByIdAsync(petUpdateRequest.PetOwnerID);

        if (applicationUser == null)
            return null;

        Pet? existingPet = await _petsRepository.GetPetByCondition(temp => temp.PetID == petUpdateRequest.PetID);

        if (existingPet == null)
            throw new ArgumentException("Invalid PetID");

        Pet pet = _mapper.Map<Pet>(petUpdateRequest);

        pet.PetOwner = applicationUser;
        Pet? updatedPet = await _petsRepository.UpdatePet(pet);

        PetResponse? updatedPetResponse = _mapper.Map<PetResponse>(updatedPet);

        return updatedPetResponse;
    }
}