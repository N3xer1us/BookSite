using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Books.ViewModels.Authors
{
    public class DisplayVM
    {

        public virtual int Id { get; set; }

        [DisplayName("First Name: ")]
        public virtual string FirstName { get; set; }

        [DisplayName("Last Name: ")]
        public virtual string LastName { get; set; }

        [DisplayName("Description: ")]    
        public virtual string Description { get; set; }

        [DisplayName("Active from: ")]
        public virtual DateTime? ActiveFrom { get; set; }

        [DisplayName("Active to: ")]
        public virtual DateTime? ActiveTo { get; set; }

        [DisplayName(" Book Count: ")]
        public int BookCount { get; set; }

        [DisplayName(" Critic Rating: ")]
        public double Rating { get; set; }
    }
}