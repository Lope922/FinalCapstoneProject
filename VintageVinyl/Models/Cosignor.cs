using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VintageVinyl.Models
{
    public class Cosignor
    {
        //pk
        public int ID { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }

        public string PhoneNumber { get; set; }
        // the virtual allows the properties of this class to be navigatable. This allows them to take advantage of certain entity frameworks functionality such as lazy loading 
        public virtual ICollection<Album> Albums { get; set; } 

    }
}