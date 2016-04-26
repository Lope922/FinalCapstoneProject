using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VintageVinyl.Models
{
    // association table that combines owners with albums they have brought in. 
    public class AssociationTable
    {
        [Required]
        public int MediaId { get; set; }

        [Required]
        public int CosignerID { get; set; }

        [Required]
        // price agreed to. Later this should be based on the condition 
        public double Price { get; set; }

        public virtual ICollection<Cosignor> Cosignors { get; set; } 
        public virtual ICollection<Album> Albums { get; set; } 

    }
}