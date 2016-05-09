using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using VintageVinyl.Models;


namespace VintageVinyl.DAL
{
	// Cosignor Context is the db connection inherited from the dbcontext class
    public class CosignorContext : DbContext
    {
       
        // this Cosignor Context is used for db transactions
		// this looks in the webconfig file to see where to connect to the database. 
        public CosignorContext() : base("CosignorContext")
        {
            //Note This code creates a DbSet property for each entity set. In Entity Framework terminology, 
            //an entity set typically corresponds to a database table, and an entity corresponds to a row in the table. 
        }

        // allows objects to be manipulated like datasets from query results. 
        public DbSet<Album> Albums { get; set; }
        public DbSet<Cosignor> Cosignors { get; set; }
        public DbSet<AssociationTable> Inventory { get; set; }

	
        // setting table creation rules
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // keeps the table names from becoming plural when the models are created using classes and Entity Framework
			
			//todo see why this isn't preventing pluralizing names. 
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }
    }
}