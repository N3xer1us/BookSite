using Books.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.ViewModels.Genres
{
    public class IndexVM
    {
        public virtual List<GenreDTO> Genres { get; set; }
        public virtual string Search { get; set; }

        public int Page { get; set; }

        public int PageCount { get; set; }
    }
}