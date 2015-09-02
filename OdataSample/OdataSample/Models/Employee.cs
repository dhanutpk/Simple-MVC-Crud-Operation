using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OdataSample.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public int DeptId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DOJ { get; set; }

        public virtual Department department { get; set; }
    }

    public class Department
    {
        public int DeptId { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Employee> employees { get; set; }
    }

    internal class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            HasKey(e => e.EmployeeId);

            Property(e => e.EmployeeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.FirstName).HasMaxLength(250).HasColumnType("nvarchar");
            Property(e => e.LastName).HasMaxLength(250).HasColumnType("nvarchar");
            Property(e => e.DOJ).IsOptional();

            ToTable("Employees");

            HasRequired(e => e.department).WithMany(d => d.employees).HasForeignKey(e => e.DeptId).WillCascadeOnDelete(true);
        }
    }

    internal class DepartmentMap : EntityTypeConfiguration<Department>
    {
        public DepartmentMap()
        {
            HasKey(d => d.DeptId);

            Property(d => d.DeptId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(d => d.Name).HasMaxLength(250).HasColumnType("nvarchar");
            Property(d => d.CreatedDate).IsOptional();

            ToTable("Deprtaments");

        }
    }

}