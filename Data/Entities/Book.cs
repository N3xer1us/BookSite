using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
   public class Book : BaseEntity
    {

        [StringLength(30)]
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
        public DateTime? DateAdded { get; set; }
        public decimal Price { get; set; }
        public double Rating { get; set; }

        [ForeignKey("AuthorId")]
        public virtual Author BookAuthor { get; set; }

        [ForeignKey("GenreId")]
        public virtual Genre BookGenre { get; set; }
    }
}
