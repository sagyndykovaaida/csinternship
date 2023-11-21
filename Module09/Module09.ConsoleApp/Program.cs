using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Module09.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee("User", 20, 400000);
            Console.WriteLine("инфо о сотруднике:");
            employee.GetInfo();
            double result = employee.CalculateAnnualSalary();
            Console.WriteLine("Annual Salary = " + result);


            Manager manager = new Manager("Manager", 25, 200000, 50000);
            Console.WriteLine("инфо о manager:");
            manager.GetInfo();
            double salaryWithBonus = manager.CalculateAnnualSalary();
            Console.WriteLine("годовой оклад включая премию = " + salaryWithBonus);


            Developer developer = new Developer("Developer", 20, 500000, 900);
            Console.WriteLine("инфо о developer");
            developer.GetInfo();
            double developerSalary = developer.CalculateAnnualSalary();
            Console.WriteLine("Salary = " + developerSalary);
            Console.ReadKey();
        }
    }
}
