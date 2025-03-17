using AutoMapper;
using BusinessLogicLayer.Dtos.PetDtos;
using BusinessLogicLayer.ServiceContracts;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryContracts;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BusinessLogicLayer.Services;

public class PetsService(IPetsRepository petsRepository, IMapper mapper) : IPetsService
{
    private readonly IPetsRepository _petsRepository = petsRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<PetResponse?> AddPet(PetAddRequest petAddRequest)
    {
        petAddRequest.PetOwnerID = Guid.Parse("fdb1c124-5416-4ce2-9f11-4af81d4963b8");
        Pet petInput = _mapper.Map<Pet>(petAddRequest);        
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