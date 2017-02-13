using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace APIs.Models
{
    public class APIsContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public APIsContext() : base("name=APIsContext")
        {
            Database.SetInitializer(new APIs.Models.DatabaseInitializer());
        }

        public System.Data.Entity.DbSet<Modelos.articles> articles { get; set; }

        public System.Data.Entity.DbSet<Modelos.stores> stores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.Configuration.LazyLoadingEnabled = false; //PAra cargar la entidades solo cuando se usan
            this.Configuration.ProxyCreationEnabled = false;
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Modelos.articles>()
                .HasRequired(fk => fk.stores)
                .WithMany()
                .HasForeignKey(x => x.store_id);
            modelBuilder.Entity<Modelos.articles>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
