using DataAccessLayer.Entities.Enum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [StringLength(200)]
        public string ProfileImage { get; set; }
        public DateTime DateOfBirth { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public DateTime RegistrationDate { get; set; }

        [StringLength(20)]
        public string Status { get; set; } // "active", "suspended", "banned"
    }
}