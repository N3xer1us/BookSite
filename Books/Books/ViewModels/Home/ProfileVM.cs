using Books.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Books.ViewModels.Home
{
    public class ProfileVM
    {
        public virtual int Id { get; set; }

        [DisplayName("Username: ")]
        public virtual string Username { get; set; }

        [DisplayName("First Name: ")]
        public virtual string FirstName { get; set; }

        [DisplayName("Last Name: ")]
        public virtual string LastName { get; set; }

        [EmailAddress]
        [DisplayName("Email: ")]
        public virtual string Email { get; set; }

        [DisplayName("Role: ")]
        public virtual string Role { get; set; }

        [DisplayName("Date of Birth: ")]
        public DateTime? DOB { get; set; }

        [DisplayName("Status: ")]
        public bool isOnline { get; set; }

        public virtual List<UserToBookDTO> Books { get; set; }

        public virtual List<FriendDTO> Friends { get; set; }

    }
}