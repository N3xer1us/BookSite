using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Books.ViewModels.Home
{
    public class LoginVM
    {

        [DisplayName("Username: ")]
        [Required(ErrorMessage="Field is Required")]
        public virtual string Username { get; set; }

        [DisplayName("Password: ")]
        [Required(ErrorMessage = "Field is Required")]
        public virtual string Password { get; set; }

    }
}