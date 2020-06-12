using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class FriendRequest: BaseEntity
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }

        [StringLength(255)]
        public string Message { get; set; }
        public DateTime? SentOn { get; set; }

        [ForeignKey("SenderId")]
        public virtual User Sender { get; set; }

        [ForeignKey("ReceiverId")]
        public virtual User Receiver { get; set; }
    }
}
