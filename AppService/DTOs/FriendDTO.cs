using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.DTOs
{
    public class FriendDTO: BaseDTO
    {

        public UserDTO User { get; set; }
        public UserDTO Friend { get; set; }
        public DateTime? CreatedOn { get; set; }

    }
}
