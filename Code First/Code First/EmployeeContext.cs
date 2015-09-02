using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First
{
    internal sealed class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("name=CodeFirst")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EmployeeContext, Code_First.Configuration>(true));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(e => e.EmployeeId);

            modelBuilder.Entity<Employee>().Property(e => e.FirstName).HasMaxLength(200).HasColumnType("nvarchar").IsRequired();
            modelBuilder.Entity<Employee>().Property(e => e.LastName).HasMaxLength(200).HasColumnType("nvarchar").IsRequired();

            modelBuilder.Entity<Employee>().Property(e => e.DOB).IsOptional();
            modelBuilder.Entity<Employee>().Property(e => e.DOJ).IsOptional();
            modelBuilder.Entity<Employee>().Property(e => e.EmailId).IsOptional().HasMaxLength(250).HasColumnType("nvarchar");
            modelBuilder.Entity<Employee>().Property(e => e.AddressLine1).IsOptional().HasMaxLength(250).HasColumnType("nvarchar");


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
    }

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false; 
        }

        protected override void Seed(EmployeeContext context)
        {
            var emplyees = new List<Employee> 
            { 
                new Employee { FirstName = "Dhanaraj", LastName = "Jogihalli", DOB = DateTime.Now, DOJ = DateTime.Now, EmailId="dhanu.tpk@gmail.com", AddressLine1="J P Nagar" } ,
                new Employee { FirstName = "Rohan", LastName = "Jogihalli", DOB = DateTime.Now, DOJ = DateTime.Now, EmailId="dhanu.tpk@gmail.com", AddressLine1="J P Nagar" } 
            };
            emplyees.ForEach(em => context.Employees.AddOrUpdate(e => new { e.FirstName }, em));
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
