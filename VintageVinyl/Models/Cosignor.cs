using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
namespace VintageVinyl.Models
{
    public class Cosignor
    {
        //pk
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
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
        // Todo add more functionality to varient inputs of phone number
        //[StringLength(10)]
		[Display(Name = "Phone Number")]
		[DisplayFormat(DataFormatString = "{0:###-###-####}")]
		[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
        
		// the virtual allows the properties of this class to be navigatable. This allows them to take advantage of certain entity frameworks functionality such as lazy loading 
        public virtual ICollection<Album> Albums { get; set; } 

    }
}