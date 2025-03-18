using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Dtos.UserDtos
{
    public class UserDtos
    {
		public Guid Id { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string ProfileImage { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Address { get; set; }
		public DateTime RegistrationDate { get; set; }
		public string Status { get; set; }
		public int Role { get; set; }
	}
}
