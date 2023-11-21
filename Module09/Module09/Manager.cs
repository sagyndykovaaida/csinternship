using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Module09
{
    public class Manager : Employee
    {
        public double bonus;

        public Manager(string name, int age, double salary, double bonus) : base(name, age, salary)
        {
            this.bonus = bonus;
        }
        public override double CalculateAnnualSalary()
        {
            return base.CalculateAnnualSalary() + bonus;
        }


    }
}
