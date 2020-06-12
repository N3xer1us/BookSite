using Books.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.ViewModels.Authors
{
    public class IndexVM
    {
        public virtual List<AuthorDTO> Authors { get; set; }
        public virtual string Search { get; set; }

        public int Page { get; set; }

        public int PageCount { get; set; }
    }
}