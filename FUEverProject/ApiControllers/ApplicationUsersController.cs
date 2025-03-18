using BusinessLogicLayer.Dtos.ApplicationUsersDtos;
using BusinessLogicLayer.Dtos.PetDtos;
using BusinessLogicLayer.ServiceContracts;
using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;
using FUEverProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace FUEverProject.ApiControllers;


[Route("api/[controller]")]
[ApiController]
public class ApplicationUsersController(IApplicationUsersService applicationUsersService) : ControllerBase
{
    private readonly IApplicationUsersService _applicationUsersService = applicationUsersService;


    //GET: /api/ApplicationUsers/{id}
    [HttpGet("{PetOwnerID}")]
    public async Task<IActionResult> Get(Guid PetOwnerID)
    {
        ApplicationUsersResponse? applicationUsersResponse = await _applicationUsersService.GetPetOwnerByIdAsync(PetOwnerID);

        if (applicationUsersResponse == null)
            return BadRequest("Invalid Application");

        return Ok(applicationUsersResponse);
    }

    //PUT api/ApplicationUsers/{id}
    [HttpPut("{PetOwnerID}")]
    public async Task<IActionResult> Put(Guid PetOwnerID, ApplicationUsersUpdateRequest applicationUsersUpdateRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (applicationUsersUpdateRequest == null)
        {
            return BadRequest("Invalid ApplicationUser data");
        }

        applicationUsersUpdateRequest.PetOwnerID = PetOwnerID;

        ApplicationUsersResponse? applicationUsersResponse = await _applicationUsersService.UpdateApplicationUsers(applicationUsersUpdateRequest);

        if (applicationUsersResponse == null)
        {
            return Problem("Error in updating ApplicationUser");
        }

        return Ok(applicationUsersResponse);
    }
}
