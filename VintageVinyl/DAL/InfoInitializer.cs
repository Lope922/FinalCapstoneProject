	using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using VintageVinyl.Models;

namespace VintageVinyl.DAL
{
    public class InfoInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CosignorContext>
    {
        //take the db context obj as input and adds new entities to the db. 
        protected override void Seed(CosignorContext context)
        {
            var cosignors = new List<Cosignor>
                // creating cosignor objects 
            {
                new Cosignor {FirstName = "Carlos", LastName = "Lopez", PhoneNumber="1234567890"},
                new Cosignor {FirstName = "Sally", LastName = "Sue", PhoneNumber="5558675309"},
                new Cosignor {FirstName = "Arturo", LastName = "Diamond", PhoneNumber="4567891264"}
            };


            // lambda expression and for loop example used from Contoso University example
            cosignors.ForEach(s => context.Cosignors.Add(s));
            context.SaveChanges();

            var albums = new List<Album>
            {
                new Album
                {AlbumName = "Kid A", Artist = "Radiohead", Price= 7.99,  DateIn = DateTime.Parse("2009-09-01")},
                new Album {AlbumName = "Beacon", Artist = "Two Door Cinema Club", Price = 9.99, DateIn = DateTime.Parse("2015-01-01")},
				new Album {AlbumName = "Hell Freezes Over" , Artist = "The Eagles" , Price = 5.99,  DateIn = DateTime.Parse("2016-04-26")}
            };
            albums.ForEach(s => context.Albums.Add(s));
            context.SaveChanges();

        }
    }
}