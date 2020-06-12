using Books.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.ViewModels.FriendRequests
{
    public class FriendsVM
    {
        public virtual int Id { get; set; }

        public virtual UserDTO User { get; set; }

        public virtual List<FriendDTO> Friends { get; set; }

        public virtual string SearchName { get; set; }

        public virtual int Page { get; set; }

        public virtual int PageCount { get; set; }
    }
}