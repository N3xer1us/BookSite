using Books.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Books.ViewModels.Users
{
    public class UserVM
    {

        Service1Client service = new Service1Client();

        public int Id { get; set; }

        [DisplayName("Username: ")]
        [Required(ErrorMessage = "Field is Required")]
        public virtual string Username { get; set; }

        [DisplayName("Password: ")]
        [Required(ErrorMessage = "Field is Required")]
        public virtual string Password { get; set; }

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

        [DisplayName("Date of Birth: ")]
        [Required(ErrorMessage ="Field is Required")]
        public DateTime? DOB { get; set; }

        [DisplayName("Role: ")]
        [Required(ErrorMessage = "Field is Required")]
        public virtual int RoleId { get; set; }

        public bool isOnline { get; set; }

        public virtual IEnumerable<SelectListItem> Roles { get { return new SelectList(service.GetRoles(), "Id", "RoleName"); } }
    }
}