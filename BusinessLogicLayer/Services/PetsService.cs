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

    public async Task<bool> DeletePet(Guid petID)
    {
        Pet? existingPet = await _petsRepository.GetPetByCondition(temp => temp.PetID == petID);

        if (existingPet == null)
            return false;

        bool isDeleted = await _petsRepository.DeletePet(petID);
        return isDeleted;
    }

    public async Task<IEnumerable<PetResponse?>> GetPets(Guid userId)
    {
        IEnumerable<Pet?> pets = await _petsRepository.GetPets(userId);

        IEnumerable<PetResponse?> petResponses = _mapper.Map<IEnumerable<PetResponse>>(pets);

        return petResponses;
    }

    public async Task<PetResponse?> UpdatePet(PetUpdateRequest petUpdateRequest)
    {
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