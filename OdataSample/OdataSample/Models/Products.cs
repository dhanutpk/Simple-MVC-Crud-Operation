using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Web;

namespace OdataSample.Models
{
    public class Products
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public decimal Price { get; set; }

    }

    internal class ProductMap : EntityTypeConfiguration<Products>
    {
        public ProductMap()
        {
            HasKey(p => p.ProductId);

            Property(p => p.ProductId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Name).HasMaxLength(250).HasColumnType("nvarchar");
            Property(p => p.Description).HasMaxLength(250).HasColumnType("nvarchar");
            ToTable("Products");
        }
    }

}