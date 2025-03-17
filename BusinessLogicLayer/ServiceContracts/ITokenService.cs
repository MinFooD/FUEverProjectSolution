﻿using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ServiceContracts
{
    public interface ITokenService
    {
		string CreateJWTToken(ApplicationUser user, List<string> roles);
	}
}
