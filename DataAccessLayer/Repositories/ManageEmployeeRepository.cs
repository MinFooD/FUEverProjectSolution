using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryContracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
	public class ManageEmployeeRepository : IManageEmployeeRepository
	{
		private readonly UserManager<ApplicationUser> _userManager;

		public ManageEmployeeRepository(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}
		public async Task<List<ApplicationUser>> GetUsersByRolesAsync(Guid storeId, List<string> roles)
		{
			var users = await _userManager.Users.ToListAsync();

			var usersWithRoles = new List<ApplicationUser>();
			foreach (var user in users)
			{
				var userRoles = await _userManager.GetRolesAsync(user);
				if (userRoles.Intersect(roles).Any())
				{
					usersWithRoles.Add(user);
				}
			}

			return usersWithRoles;
		}
	}
}
