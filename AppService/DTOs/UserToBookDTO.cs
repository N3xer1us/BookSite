using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.DTOs
{
    public class UserToBookDTO: BaseDTO
    {

        public BookDTO Book { get; set; }

        public UserDTO bookUser { get; set; }

    }
}
