using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_First_Approach
{
    class Program
    {
        static void Main(string[] args)
        {

            EmployeeContainer container = new EmployeeContainer();
            Department dept = new Department { Name = "Software", Description = "Software", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now };
            Employee emp = new Employee { FirstName = "Dhanaraj", LastName = "Jogihalli", EmailId = "dhanu.tpk@gmail.com", DOB = DateTime.Now, DOJ = DateTime.Now };
            //EmployeeAddress addr = new EmployeeAddress { AddressLine1 = "J P Nagar 1st Phase", AddressLine2 = "Sarakki 560078" };
            container.Departments.Add(dept);
            container.Employees.Add(emp);
            //container.EmployeeAddresses.Add(addr);
            container.SaveChanges();
        }
    }
}
