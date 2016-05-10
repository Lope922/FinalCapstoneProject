using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VintageVinyl.Models
{
	/// <summary>
	/// NO Metadata available yet. 
	/// </summary>
    public class Cosignor
    {
        //pk
        [Key]
        public int CosignorID { get; set; }
        
        [Required]
        [Display(Name = "First Name")]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
		[MinLength(10)]
		[DisplayFormat(DataFormatString = "{0:###-###-####}", ApplyFormatInEditMode = true)]
        public string PhoneNumber { get; set; }


		// trying to create a getallCosignors method to get all the cosignors I used. 
		// Creating an iterable list here allows me to incorporate LINQ functionality. 
		// this is actually done below using Icollection 
		//public static List<Cosignor> GetAllCosignors();
		

        // the virtual allows the properties of this class to be navigatable. This allows them to take advantage of certain entity frameworks functionality such as lazy loading 
        public virtual ICollection<Album> Albums { get; set; } 

    }
}