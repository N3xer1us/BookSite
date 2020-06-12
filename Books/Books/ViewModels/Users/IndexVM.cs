using Books.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.ViewModels.Users
{
    public class IndexVM
    {
        public virtual List<UserDTO> Users { get; set; }
        public virtual string Search { get; set; } = null;

        public int Page { get; set; }

        public int PageCount { get; set; }
    }
}