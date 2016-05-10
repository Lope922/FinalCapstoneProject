using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VintageVinyl.Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		// this test checks to see if the date time is greater than today 
		
			// pass in a datetime to see if the user input sell date is before the current date , or date in for the album 
			public void TestMethod1()
		{

			// remember arrange 
			var dateTimeInput = DateTime.Parse("05/06/2015");

			var today = DateTime.Today.Date;

			//act 


			//assert


			// given this date time , which is a year in the past should throw a flag 
			if (dateTimeInput > today)
			{
				Assert.Fail();
				Console.WriteLine("Date input is invalid");
				//mbox("value cannot be in the past");

			}
			else if (dateTimeInput < today)
			{
				Assert.IsTrue(dateTimeInput < today); 
			}
			
			
		}

		// method to chek and see if the entry contains 
		public void CheckToForDuplicateEntries()
		{

		}
	}
}
