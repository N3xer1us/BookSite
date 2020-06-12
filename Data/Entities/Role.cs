using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Role: BaseEntity
    {

        [StringLength(20)]
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public int UserCount { get; set; }

    }
}
