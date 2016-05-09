using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VintageVinyl.Models;
using Microsoft.VisualStudio.TestTools.Resources;

namespace VintageVinyl.Tests.Features
{
	[TestClass]
	public class UnitTest1
	{
		
		// this test method is trying to add an Cosignor to the database 
		[TestMethod]
		public void InsertTest()
		{
			//arrange 
			new Cosignor {FirstName="Carlos" , LastName= "Lopez",PhoneNumber="6542223333"};

			var mockContext = new Mock<ControllerContext>();


		}
	}
}
