using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeContext context = new EmployeeContext();
            var employees = context.Employees.ToList();
            Console.WriteLine("Count of employees " + employees.Count);
            Console.ReadLine();
        }
    }
}
