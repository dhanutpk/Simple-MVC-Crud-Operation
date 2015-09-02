using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp1.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }
    }

    sealed internal class ProductContext : DbContext
    {
        public ProductContext()
            : base("ProductConnection")
        {

        }
        
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.ProductId);

            modelBuilder.Entity<Product>().Property(p => p.ProductId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(200).HasColumnType("nvarchar");
            modelBuilder.Entity<Product>().Property(p => p.Description).IsOptional().HasMaxLength(200).HasColumnType("nvarchar");
            modelBuilder.Entity<Product>().Property(p => p.CreatedDate).IsOptional();
            
            base.OnModelCreating(modelBuilder);
        }    
    }
}
