using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace VintageVinyl.Models
{
    public class Album
    {
        // pk should auto increment the pk id 
        public int ID { get; set; }


        [Required]
        public string Artist { get; set; }


        // validation applied directly to class property
        [Required]
        [StringLength(60, MinimumLength =2)]
        public string AlbumName { get; set; }
        
        [Required]
        [Display(Name="Date Recieved")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateIn { get; set; }

        // question mark allows nulls in this field ,because albums don't have a sell date yet 
        public DateTime? DateOut { get; set; }

        [Required]
        [RegularExpression(@"^[+-]?[0-9]{1,3}(?:,?[0-9]{3})*(?:\.[0-9]{2})?$")]
        public decimal Price { get; set; }
        //TODO modify this one i have the basics working. 
         // would also like to add types , conidition , and initial price, 

        // the same functionality as in Cosignors through thier relationships allows Albums to interface with cosignors
        public virtual ICollection<Cosignor> Cosignors { get; set; }

        // 
        // [RegularExpression(@"^[A-Z+[a-zA-Z'' -\s]*$")]
        // from here i am moving onto the DAL Data Access Layer
    }
}