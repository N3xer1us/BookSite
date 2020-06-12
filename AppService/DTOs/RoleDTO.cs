using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.DTOs
{
    public class RoleDTO: BaseDTO
    {

        public string RoleName { get; set; }

        public string RoleDescription { get; set; }

        public int UserCount { get; set; }

    }
}
