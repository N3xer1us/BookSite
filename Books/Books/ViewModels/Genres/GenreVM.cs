using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Books.ViewModels.Genres
{
    public class GenreVM
    {
        public virtual int Id { get; set; }

        [DisplayName("Genre Name: ")]
        [Required(ErrorMessage = "This Field is Required")]
        public virtual string GenreName { get; set; }

        [DisplayName("Description: ")]
        [Required(ErrorMessage = "This Field is Required")]
        public virtual string Description { get; set; }

        public int BookCount { get; set; }

        [DisplayName("Genre Rating: ")]
        [Required(ErrorMessage ="This Field is Requred")]
        public double Rating { get; set; }

        public DateTime? LastUpdated { get; set; }
    }
}