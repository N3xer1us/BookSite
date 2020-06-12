using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
   public class Friend: BaseEntity
    {
        public int UserId { get; set; }
        public int FriendId { get; set; }
        public DateTime? CreatedOn { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("FriendId")]
        public virtual User FriendUser { get; set; }
    }
}
