using BusinessLogicLayer.Dtos.PetDtos;
using BusinessLogicLayer.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace FueverProject.ApiControllers;

[Route("api/[controller]")]
[ApiController]
public class PetsController(IPetsService petsService) : ControllerBase
{
    private readonly IPetsService _petsService = petsService;

    //GET: /api/Pets
    [HttpGet]
    public async Task<IEnumerable<PetResponse?>> Get()
    {
        IEnumerable<PetResponse?> pets = await _petsService.GetPets();
        return pets;
    }
}