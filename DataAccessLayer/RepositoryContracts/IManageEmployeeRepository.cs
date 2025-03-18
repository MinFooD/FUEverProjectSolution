using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.RepositoryContracts
{
    public interface IManageEmployeeRepository
    {
		Task<List<ApplicationUser>> GetUsersByRolesAsync(Guid storeId, List<string> roles);
	}
}
