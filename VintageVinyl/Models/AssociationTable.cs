using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace VintageVinyl.Models
{
    // association table that combines owners with albums they have brought in. 
    public class AssociationTable
    {   //todo pick up from here 
        //pk      
        [Key]  
        public int ItemNum { get; set; }

        [Required]       
        [ForeignKey("Cosignors")]
        public int CosignorID { get; set; }
        [Required]
        [ForeignKey("Albums")]
        public int AlbumID { get; set; }
        // price agreed to. Later this should be based on the condition 

        [Required]
        [RegularExpression(@"^[+-]?[0-9]{1,3}(?:,?[0-9]{3})*(?:\.[0-9]{2})?$")]
        public double Price { get; set; }

        // optional. Only needs to be added when item is sold. 
        public DateTime? DateSold { get; set; }

        public virtual Cosignor Cosignors { get; set; } 
        public virtual Album Albums { get; set; } 

    }
}