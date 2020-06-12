using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.DTOs
{
    public class BookDTO: BaseDTO
    {

        public string Title { get; set; }

        public AuthorDTO bookAuthor { get; set; }

        public GenreDTO bookGenre { get; set; }

        public string Description { get; set; }

        public DateTime? DateAdded { get; set; }

        public decimal Price { get; set; }

        public double Rating { get; set; }

    }
}
