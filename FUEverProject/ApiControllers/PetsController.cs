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
            return BadRequest("Invalid pet data");
        }

        PetResponse? petResponse = await _petsService.AddPet(petAddRequest);

        if (petResponse == null)
        {
            return Problem("Error in adding pet");
        }

        return Created($"api/Pets/search/petid/{petResponse?.PetID}", petResponse);
    }

    //PUT api/Pets/{petID}
    [HttpPut("{petID}")]
    public async Task<IActionResult> Put(Guid petID, PetUpdateRequest petUpdateRequest)
    {
        if (petUpdateRequest == null)
        {
            return BadRequest("Invalid pet data");
        }

        petUpdateRequest.PetID = petID;

        PetResponse? petResponse = await _petsService.UpdatePet(petUpdateRequest);

        if (petResponse == null)
        {
            return Problem("Error in updating pet");
        }

        return Ok(petResponse);
    }

    //DELETE api/Pets/{petID}
    [HttpDelete("{petID}")]
    public async Task<IActionResult> Delete(Guid petID)
    {
        if (petID == Guid.Empty)
            return BadRequest("Invalid order ID");

        bool isDeleted = await _petsService.DeletePet(petID);

        if (!isDeleted)
            return Problem("Error in deleting pet");

        return Ok(isDeleted);
    }
}