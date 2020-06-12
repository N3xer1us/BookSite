using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class User : BaseEntity
    {
        [StringLength(30)]
        public string Username { get; set; }
        [StringLength(30)]
        public string Password { get; set; }
        [StringLength(30)]
        public string FirstName { get; set; }
        [StringLength(30)]
        public string LastName { get; set; }
        [StringLength(30)]
        public string Email { get; set; }
        public DateTime? DOB { get; set; }
        public int RoleId { get; set; }
        public bool isOnline { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role UserRole { get; set; }

    }
}
