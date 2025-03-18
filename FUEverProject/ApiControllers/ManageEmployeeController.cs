using BusinessLogicLayer.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FUEverProject.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageEmployeeController : ControllerBase
    {
		private readonly IManageEmployeeService _manageEmployeeService;
		public ManageEmployeeController(IManageEmployeeService manageEmployeeService)
		{
			_manageEmployeeService = manageEmployeeService;
		}

		[HttpGet("GetUsersByRoles")]
		public async Task<IActionResult> GetUsersByRoles(Guid storeId)
		{
			var roles = new List<string> { "Staff", "Employee" };
			var userDtos = await _manageEmployeeService.GetUsersByRolesAsync(storeId, roles);

			if (userDtos != null && userDtos.Count > 0)
			{
				return Ok(userDtos);
			}
			return NotFound("No users found with the specified roles.");
		}
	}
}
