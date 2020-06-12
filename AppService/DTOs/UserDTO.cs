using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.DTOs
{
    public class UserDTO: BaseDTO
    {

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime? DOB { get; set; }

        public RoleDTO userRole { get; set; }

        public bool isOnline { get; set; }

    }
}
