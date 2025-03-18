using BusinessLogicLayer.ServiceContracts;
using DataAccessLayer.Entities.EntityEnums;
using DataAccessLayer.Entities;
using FUEverProject.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FUEverProject.ApiControllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ManageEmployeeController : ControllerBase
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IManageEmployeeService _manageEmployeeService;

		public ManageEmployeeController(UserManager<ApplicationUser> userManager, IManageEmployeeService manageEmployeeService)
		{
			_userManager = userManager;
			_manageEmployeeService = manageEmployeeService;
		}

		[HttpGet]
		[Route("{storeId:Guid}")]
		public async Task<IActionResult> GetUsersByRoles([FromRoute] Guid storeId)
		{
			var roles = new List<string> { "Staff", "Employee" };
			var userDtos = await _manageEmployeeService.GetUsersByRolesAsync(storeId, roles);

			if (userDtos != null && userDtos.Count > 0)
			{
				return Ok(userDtos);
			}
			return NotFound("No users found with the specified roles.");
		}

		[HttpPost]
		[Route("RegisterEmployee/{storeId:Guid}")]
		[Authorize(Roles = "StoreOwner")]
		public async Task<IActionResult> RegisterEmployee([FromRoute] Guid storeId, [FromBody] RegisterRequestViewModel registerRequestViewModel)
		{
			string[] roles;

			if (registerRequestViewModel.Roles == 1)
			{
				roles = new string[] { "Staff" };
			}
			else
			{
				roles = new string[] { "Employee" };
			}
			var identityUser = new ApplicationUser
			{
				Status = UserStatus.active.ToString(),
				RegistrationDate = DateTime.Now,
				Address = registerRequestViewModel.Address,
				DateOfBirth = registerRequestViewModel.DateOfBirth,
				PhoneNumber = registerRequestViewModel.Phone,
				UserName = registerRequestViewModel.UserName,
				ProfileImage = registerRequestViewModel.Image,
				Email = registerRequestViewModel.Gmail,
				StoreId = storeId
			};

			var identityResult = await _userManager.CreateAsync(identityUser, registerRequestViewModel.Password);

			if (identityResult.Succeeded)
			{
				//Add roles to this user
				identityResult = await _userManager.AddToRolesAsync(identityUser, roles);
				if (identityResult.Succeeded)
				{
					return Ok("Employee or Staff was registered!");
				}
			}
			return BadRequest(identityResult.Errors);
		}

		[HttpPost]
		[Route("UpdateEmployeeStatus/{userId:Guid}")]
		[Authorize(Roles = "StoreOwner")]
		public async Task<IActionResult> UpdateEmployeeStatus([FromRoute] Guid userId, int status)
		{
			var user = await _manageEmployeeService.UpdateEmployeeStatus(userId, status);
			if (user != null)
			{
				return Ok(user);
			}
			return NotFound("User not found or user is not an employee or staff.");
		}
	}
}
