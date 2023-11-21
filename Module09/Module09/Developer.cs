using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module09
{
    public class Developer : Employee
    {
        private int linesOfCodePerDay;

        public Developer(string name, int age, double salary, int linesOfCodePerDay) : base(name, age, salary)
        {
            this.linesOfCodePerDay = linesOfCodePerDay;
        }
        public override double CalculateAnnualSalary()
        {
            double codePaymentRate = 0.5;
            double additionalSalary = linesOfCodePerDay * codePaymentRate * 250; 

            return base.CalculateAnnualSalary() + additionalSalary;
        }
    }
}
