using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Books.ViewModels.Genres
{
    public class DisplayVM
    {
        public virtual int Id { get; set; }

        [DisplayName("Genre Name: ")]
        public virtual string GenreName { get; set; }

        [DisplayName("Description: ")]
        public virtual string Description { get; set; }

        [DisplayName("Book Count: ")]
        public int BookCount { get; set; }

        [DisplayName("Genre Rating: ")]
        public double Rating { get; set; }

        [DisplayName("Last Updated on: ")]
        public DateTime? LastUpdated { get; set; }
    }
}