using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace VintageVinyl.Models
{
    public class Album
    {
        public int ID { get; set; }
        public string AlbumName { get; set; }

        public string Artist { get; set; }

        public DateTime DateIn { get; set; }

        // question mark allows nulls in this field ,because albums don't have a sell date yet 
        public DateTime? DateOut { get; set; }

        //TODO modify this one i have the basics working. 
         // would also like to add types , conidition , and initial price, 

        // want the same functionality as in Cosignors through thier relationships
        public virtual ICollection<Cosignor> Cosignors { get; set; } 

        // from here i am moving onto the DAL Data Access Layer
    }
}