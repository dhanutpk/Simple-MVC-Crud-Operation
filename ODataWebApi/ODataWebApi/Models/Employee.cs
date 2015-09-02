using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ODataWebApi.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DOJ { get; set; }

        public DateTime DOB { get; set; }

    }
    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("name=OdataConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EmployeeContext, EmployeeContextMigrationConfiguration>());
        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasKey(x => x.Id);
        }
    }

    class EmployeeContextMigrationConfiguration : DbMigrationsConfiguration<EmployeeContext>
    {
        public EmployeeContextMigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }
    }
}