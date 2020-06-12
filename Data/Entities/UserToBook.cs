using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class UserToBook:BaseEntity
    {
        public int UserId { get; set; }
        public int BookId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
    }
}
