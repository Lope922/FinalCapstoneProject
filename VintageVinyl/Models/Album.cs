using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace VintageVinyl.Models
{
	public enum Condition
	{// call to string method to use them as strings 
		Poor, Fair, Good, Excellent
	}
    public class Album
    {
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        // validation applied directly to class property
        [Required]
        [StringLength(60, MinimumLength =2)]
       // [RegularExpression(@"^[A-Z+[a-zA-Z'' -\s]*$")]
        public string AlbumName { get; set; }

        [Required]
        public string Artist { get; set; }

        [Required]
        [Display(Name="Date Recieved")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]

        public DateTime DateIn { get; set; }

        // question mark allows nulls in this field ,because albums don't have a sell date yet 
        public DateTime? DateOut { get; set; }

		public Condition Condition {get; set;}

		// have a cosignorID mapped to the album number they own 
		public int? CosinorID { get; set; }

		//todo associate price based on codition of product. 
        // want the same functionality as in Cosignors through thier relationships
        public virtual ICollection<Cosignor> Cosignors { get; set; } 

		

        // from here i am moving onto the DAL [Data Access Layer]
    }
}