﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VintageVinyl.Models
{
    public class Cosignor
    {
        //pk
        public int ID { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        // todo add regular expression and reprint the phone number displaying with parenthesis and dashes
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        // the virtual allows the properties of this class to be navigatable. This allows them to take advantage of certain entity frameworks functionality such as lazy loading 
        public virtual ICollection<Album> Albums { get; set; } 

    }
}