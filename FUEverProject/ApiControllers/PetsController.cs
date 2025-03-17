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

    //POST api/Pets
    [HttpPost]
    public async Task<IActionResult> Post(PetAddRequest petAddRequest)
    {
        if (petAddRequest == null)
        {
            return BadRequest("Invalid order data");
        }

        PetResponse? petResponse = await _petsService.AddPet(petAddRequest);

        if (petResponse == null)
        {
            return Problem("Error in adding pet");
        }


        return Created($"api/Pets/search/petid/{petResponse?.PetID}", petResponse);
    }
}