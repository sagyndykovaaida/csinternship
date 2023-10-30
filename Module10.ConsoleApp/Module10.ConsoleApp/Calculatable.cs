using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.ConsoleApp
{
    public interface ICalculatable
    {
        double Add(double a, double b);
        double Multiply(double a, double b);
        double Subtract(double a, double b);
        double Divide(double a, double b);
    }

    public class Calculator : ICalculatable
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Subtract(double a, double b)
        {
            return a - b;
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }

        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed.");
            }
            return a / b;
        }
    }

    static void Main()
    {
        ICalculatable calculatable = new Calculator();
        double result1 = calculatable.Add(2, 5);
        double result2 = calculatable.Subtract(20, 5);
        double result3 = calculatable.Multiply(2, 5);
        double result4 = calculatable.Divide(10, 2);
        Console.WriteLine(result1);
        Console.WriteLine(result2);
        Console.WriteLine(result3);
        Console.WriteLine(result4);
        Console.ReadKey();
    }
}
