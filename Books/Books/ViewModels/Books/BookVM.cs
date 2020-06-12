using Books.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Books.ViewModels.Books
{
    public class BookVM
    {

        Service1Client service = new Service1Client();

        public int Id { get; set; }

        [DisplayName("Title: ")]
        [Required(ErrorMessage = "Field is Required")]
        public virtual string Title { get; set; }

        [DisplayName("Author: ")]
        [Required(ErrorMessage = "Field is Required")]
        public virtual int AuthorId { get; set; }

        [DisplayName("Genre: ")]
        [Required(ErrorMessage = "Field is Required")]
        public virtual int GenreId { get; set; }

        [DisplayName("Description: ")]
        [Required(ErrorMessage = "Field is Required")]
        public virtual string Description { get; set; }

        public DateTime? DateAdded { get; set; }

        [DisplayName("Price: ")]
        [Required(ErrorMessage = "Field is Required")]
        public decimal Price { get; set; }

        public double Rating { get; set; }

        public virtual IEnumerable<SelectListItem> Genres { get { return new SelectList(service.GetGenres(), "Id", "GenreName"); } }
        public virtual IEnumerable<SelectListItem> Authors { get { return new SelectList(service.GetAuthors(), "Id", "LastName"); } }
    }
}