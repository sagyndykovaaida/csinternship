using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module09
{
    public class Employee
    {
        public string name;
        public int age;
        public double salary;

        public Employee(string name, int age, double salary) {
            this.name = name;
            this.age = age;
            this.salary = salary;
        }
        public void GetInfo()
        {
            Console.WriteLine("Name: {0}, Age: {1} , Salary: {2}", name,age,salary);
        }
        public virtual double  CalculateAnnualSalary()
        {
            return salary * 12;
        }
    }
}
