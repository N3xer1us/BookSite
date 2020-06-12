using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
   public class Genre: BaseEntity
    {
        [StringLength(30)]
        public string GenreName { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public int BookCount { get; set; }
        public double Rating { get; set; }
        public DateTime? LastUpdated { get; set; }

    }
}
