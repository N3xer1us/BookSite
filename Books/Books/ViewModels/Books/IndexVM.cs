using Books.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Books.ViewModels.Books
{
    public class IndexVM
    {

        Service1Client service = new Service1Client();

        public virtual int GenreId { get; set; }

        public virtual int AuthorId { get; set; } 

        public string SearchTitle { get; set; }


        
        public virtual IEnumerable<SelectListItem> Genres { get { return new SelectList(service.GetGenres(), "Id", "GenreName"); } }
        public virtual IEnumerable<SelectListItem> Authors { get { return new SelectList(service.GetAuthors(), "Id", "LastName"); } }
        
        public virtual List<BookDTO> Books { get; set; }

        public int Page { get; set; }

        public int PageCount { get; set; }

    }
}