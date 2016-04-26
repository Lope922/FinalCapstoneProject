using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Web;
// brought in for foreign key 
using System.ComponentModel.DataAnnotations.Schema;
namespace VintageVinyl.Models
{
    public class Inventory 
    {
        // each item needs to have and id , which should be the album id 
        // pk match  
        public int itemID { get; set; }

        // that album id can be attatched to several different customers who brought in the album 
        // TODO finish builing this model so that i can begin adding test data to this table. 
        [ForeignKey("AlbumID")]
    
        // by the album id we should be able to grab all of those that do not have a sold date 

        
    public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Cosignor> Cosignors { get; set; } 
    } 

    }
