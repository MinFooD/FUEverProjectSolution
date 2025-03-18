using AutoMapper;
using BusinessLogicLayer.Dtos.UserDtos;
using BusinessLogicLayer.ServiceContracts;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryContracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
	public class ManageEmployeeService : IManageEmployeeService
	{
		private readonly IManageEmployeeRepository _manageEmployeeRepository;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IMapper _mapper;

		public ManageEmployeeService(IManageEmployeeRepository manageEmployeeRepository, UserManager<ApplicationUser> userManager, IMapper mapper)
		{
			_manageEmployeeRepository = manageEmployeeRepository;
			_userManager = userManager;
			_mapper = mapper;
		}

		public async Task<List<UserDtos>> GetUsersByRolesAsync(Guid storeId, List<string> roles)
		{
			var users = await _manageEmployeeRepository.GetUsersByRolesAsync(storeId, roles);
			var userDtos = new List<UserDtos>();

			foreach (var user in users)
			{
				var userDto = _mapper.Map<UserDtos>(user);
				userDto.Role = await GetRoleFromUser(user);
				userDtos.Add(userDto);
			}

			return userDtos;
		}

		public async Task<int> GetRoleFromUser(ApplicationUser user)
		{
			if (user == null) return 0;
			var roles = await _userManager.GetRolesAsync(user);
			if (roles.Contains("Staff"))
				return 1;
			if (roles.Contains("Employee"))
				return 2;
			return 0;
		}
	}
}
