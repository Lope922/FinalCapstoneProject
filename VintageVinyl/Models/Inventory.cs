using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Web;
// brought in for foreign key 
using System.ComponentModel.DataAnnotations.Schema;
namespace VintageVinyl.Models
{
    public class Inventory : Cosignor
    {
        // pk match 
        public int itemID { get; set; }

        [ForeignKey("Cosigner.ID")]
        // need the id of the cosigner that brought in the album
        public int BroughtInBy { get; set; }

        // TODO finish builing this model so that i can begin adding test data to this table. 
        [ForeignKey("AlbumID")]
        
        public List<Album> Albums { get; set; }

       
        

    
        // need the inital selling price agreed upon 
    

    public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Cosignor> Cosignors { get; set; } 
    } 

    }
}