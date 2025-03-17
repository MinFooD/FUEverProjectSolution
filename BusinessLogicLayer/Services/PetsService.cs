using AutoMapper;
using BusinessLogicLayer.Dtos.PetDtos;
using BusinessLogicLayer.ServiceContracts;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryContracts;

namespace BusinessLogicLayer.Services;

public class PetsService(IPetsRepository petsRepository, IMapper mapper) : IPetsService
{
    private readonly IPetsRepository _petsRepository = petsRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<PetResponse?>> GetPets()
    {
        IEnumerable<Pet?> pets = await _petsRepository.GetPets();

        IEnumerable<PetResponse?> petResponses = _mapper.Map<IEnumerable<PetResponse>>(pets);

        return petResponses;
    }
}