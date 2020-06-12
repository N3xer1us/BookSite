using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Books.ViewModels.FriendRequests
{
    public class FriendRequestVM
    {
        public virtual int FriendId { get; set; }

        public virtual string Name { get; set; }

        [DisplayName("Message: ")]
        public virtual string Message { get; set; }
    }
}