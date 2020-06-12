using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Books.ViewModels.Home
{
    public class EditVM
    {
        public virtual int Id { get; set; }

        [DisplayName("Username: ")]
        [Required(ErrorMessage = "Field is Required")]
        public virtual string Username { get; set; }

        [DisplayName("Password: ")]
        [Required(ErrorMessage = "Field is Required")]
        public string Password { get; set; }

        [DisplayName("First Name: ")]
        [Required(ErrorMessage = "Field is Required")]
        public virtual string FirstName { get; set; }

        [DisplayName("Last Name: ")]
        [Required(ErrorMessage = "Field is Required")]
        public virtual string LastName { get; set; }

        [EmailAddress]
        [DisplayName("Email: ")]
        [Required(ErrorMessage = "Field is Required")]
        public virtual string Email { get; set; }

        public virtual int RoleId { get; set; }

        public virtual bool isOnline { get; set; }

        [DisplayName("Date of Birth: ")]
        [Required(ErrorMessage ="Dield is Required")]
        public DateTime? DOB { get; set; }


    }
}