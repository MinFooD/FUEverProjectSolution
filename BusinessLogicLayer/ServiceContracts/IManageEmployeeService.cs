using BusinessLogicLayer.Dtos.UserDtos;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ServiceContracts
{
    public interface IManageEmployeeService
    {
		Task<List<UserDtos>> GetUsersByRolesAsync(Guid storeId,List<string> roles);

		Task<int> GetRoleFromUser(ApplicationUser user);

	}
}
