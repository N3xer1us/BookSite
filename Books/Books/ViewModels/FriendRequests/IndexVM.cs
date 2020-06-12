using Books.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.ViewModels.FriendRequests
{
    public class IndexVM
    {
        public virtual string SearchName { get; set; }

        public virtual List<FriendRequestDTO> FriendRequests { get; set; }

        public int Page { get; set; }

        public int PageCount { get; set; }

    }
}