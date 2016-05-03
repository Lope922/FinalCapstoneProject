using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using VintageVinyl.Models;


namespace VintageVinyl.DAL
{
	// Cosignor Context is the db connection inherited from the dbcontext class
    public class CosignorContext : DbContext
    {
        
        // this Cosignor ext is being used for the connection string to the database for CRUD functionality. 

        public CosignorContext() : base("CosignorContext")
        {
            //Note This code creates a DbSet property for each entity set. In Entity Framework terminology, 
            //an entity set typically corresponds to a database table, and an entity corresponds to a row in the table. 
        }

        // allows objects to be manipulated like datasets from query results. 
        public DbSet<Album> Albums { get; set; }
        public DbSet<Cosignor> Cosignors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // keeps the table names from becoming plural when the models are created using classes and Entity Framework
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }
    }
}