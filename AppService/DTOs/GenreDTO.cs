using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.DTOs
{
    public class GenreDTO: BaseDTO
    {

        public string GenreName { get; set; }

        public string Description { get; set; }

        public int BookCount { get; set; }

        public double Rating { get; set; }

        public DateTime? LastUpdated { get; set; }

    }
}
