using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OdataSample.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string EmailId { get; set; }

        public DateTime DOB { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }

    public class Order
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public virtual Customer customer { get; set; }

    }
    internal class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            HasKey(c => c.CustomerId);

            Property(c => c.CustomerId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Name).HasMaxLength(250).HasColumnType("nvarchar");
            Property(c => c.EmailId).HasMaxLength(250).HasColumnType("nvarchar");
            Property(c => c.DOB).IsOptional();
            ToTable("Customers");
        }
    }
    internal class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            HasKey(o => o.OrderId);

            Property(o => o.OrderId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(o => o.Price).IsRequired();
            Property(o => o.CustomerId).IsRequired();
            Property(o => o.Quantity).IsRequired();

            ToTable("Orders");

            HasRequired(o => o.customer).WithMany(c => c.Orders).HasForeignKey(o => o.CustomerId).WillCascadeOnDelete(true);
        }
    }
}