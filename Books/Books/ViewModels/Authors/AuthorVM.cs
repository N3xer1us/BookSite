using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Books.ViewModels.Authors
{
    public class AuthorVM
    {
        public virtual int Id { get; set; }

        [DisplayName("First Name: ")]
        [Required(ErrorMessage = "This Field is Required")]
        public virtual string FirstName { get; set; }

        [DisplayName("Last Name: ")]
        [Required(ErrorMessage = "This Field is Required")]
        public virtual string LastName { get; set; }

        [DisplayName("Description: ")]
        [Required(ErrorMessage = "This Field is Required")]
        public virtual string Description { get; set; }

        [DisplayName("Active from: ")]
        [Required(ErrorMessage = "This Field is Required")]
        public virtual DateTime? ActiveFrom { get; set; }

        [DisplayName("Active to: ")]
        [Required(ErrorMessage = "This Field is Required")]
        public virtual DateTime? ActiveTo { get; set; }

        public int BookCount { get; set; }

        public double Rating { get; set; }
    }
}