using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.DTOs
{
    public class FriendRequestDTO: BaseDTO
    {

        public UserDTO Sender { get; set; }

        public UserDTO Receiver { get; set; }

        public string Message { get; set; }

        public DateTime? SentOn { get; set; }

    }
}
