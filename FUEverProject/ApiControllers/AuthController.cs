using BusinessLogicLayer.ServiceContracts;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Enum;
using FUEverProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FueverProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;

		public AuthController(UserManager<ApplicationUser> userManager, ITokenService tokenService)
		{
			_userManager = userManager;
			_tokenService = tokenService;
		}

		[HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestViewModel loginRequestViewModel)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestViewModel.UserName);

            if (user != null)
            {
                var checkPasswordResult = await _userManager.CheckPasswordAsync(user, loginRequestViewModel.Password);

                if (checkPasswordResult)
                {
					var roles = await _userManager.GetRolesAsync(user);
					var jwtToken = _tokenService.CreateJWTToken(user, roles.ToList());
					// Tạo object response chứa cả thông tin user và roles
					var response = new LoginRespondeViewModel
					{
						JwtToken = jwtToken,
					};
					return Ok(response);
				}
            }
            return BadRequest("Username or password incorrect");
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestViewModel registerRequestViewModel)
        {
            string[] roles;

            if (registerRequestViewModel.Roles == 2)
            {
                roles = new string[] { "StoreOwner" };
            }
            else
            {
                roles = new string[] { "PetOwner" };
            }
			var identityUser = new ApplicationUser
			{
				Status = UserStatus.active.ToString(),
				RegistrationDate = DateTime.Now,
				Address = registerRequestViewModel.Address,
				DateOfBirth = registerRequestViewModel.DateOfBirth,
				PhoneNumber = registerRequestViewModel.Phone,
				UserName = registerRequestViewModel.UserName,
				ProfileImage = "default.jpg",
				Email = registerRequestViewModel.Gmail
			};

            var identityResult = await _userManager.CreateAsync(identityUser, registerRequestViewModel.Password);

            if (identityResult.Succeeded)
            {
                //Add roles to this user
                identityResult = await _userManager.AddToRolesAsync(identityUser, roles);
                if (identityResult.Succeeded)
                {
                    return Ok("User was registered! please login.");
                }
            }
            return BadRequest("Something went wrong!");
        }
    }
}