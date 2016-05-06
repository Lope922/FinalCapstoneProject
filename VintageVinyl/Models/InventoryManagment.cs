using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VintageVinyl.Models
{
	// TODO maybe come back to this and see if this is needed 
	public class InventoryManagment
	{
		//pk for this item mapping 
		public int ID { get; set; }
		
		[ForeignKey("Cosignor")]
		// id of the user's whose inventory is being managed 
		public int CosignorID { get; set; }
		[ForeignKey("Album")]
		// list of item IDs 
		public int AlbumID { get; set; }

		[Required]	
		public int Price { get; set; }

		[Display(Name = "Date Sold")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = false)]

		public DateTime? DateOut { get; set;}//DateOut.Equals(DateTime.Today.ToShortDateString()); } }

		
		public virtual Cosignor Cosignors { get; set; }
		public virtual Album Albums { get; set; }
	}
}