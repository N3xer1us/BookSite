using Books.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Books.ViewModels.Books
{
    public class DisplayVM
    {

        public virtual int Id { get; set; }

        [DisplayName("Title: ")]
        public virtual string Title { get; set; }

        [DisplayName("Author: ")]
        public virtual string Author { get; set; }

        [DisplayName("Genre: ")]
        public virtual string Genre { get; set; }

        [DisplayName("Description: ")]
        public virtual string Description { get; set; }

        [DisplayName("Date Added: ")]
        public DateTime? DateAdded { get; set; }

        [DisplayName("Price: ")]
        public decimal Price { get; set; }

        [DisplayName("Rating: ")]
        public double Rating { get; set; }

        public virtual List<UserToBookDTO> Users { get; set; }
    }
}