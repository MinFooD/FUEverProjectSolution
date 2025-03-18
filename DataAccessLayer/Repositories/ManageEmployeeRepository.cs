using DataAccessLayer.Entities;
using DataAccessLayer.Entities.EntityEnums;
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
			var users = await _userManager.Users.Where(x => x.StoreId == storeId).ToListAsync();

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

		public async Task<ApplicationUser?> UpdateStatusEmployee(Guid userId, int status)
		{
			var roles = new List<string> { "Staff", "Employee" };
			var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
			if (user == null) return null;
			var userRoles = await _userManager.GetRolesAsync(user);
			if (userRoles.Intersect(roles).Any())
			{
				if (status == 1)
				{
					user.Status = UserStatus.active.ToString();
					await _userManager.UpdateAsync(user);
				}
				else if(status == 0)
				{
					user.Status = UserStatus.suspended.ToString();
					await _userManager.UpdateAsync(user);
				}
				return user;
			}

			return null;
		}
	}
}

