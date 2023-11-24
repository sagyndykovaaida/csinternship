using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppModule12
{
    public delegate double MathOperation(double x, double y);

    internal class MathOperationProgram
    {
        public static double Add(double x, double y)
        {
            return x + y;
        }
        public static double Subtract(double x, double y)
        {
            return x - y;
        }
        public static double Multiply(double x, double y)
        {
            return x * y;
        }
        public static double Divide(double x, double y)
        {
            if(y != 0)
                return x / y;
            else
            {
                return double.NaN;
            }
        } 

        public static void PerformOperation(double x, double y, MathOperation operation)
        {
            double result = operation(x, y);
            Console.WriteLine($"Результат:" + result);
        }

        static void Main()
        {
            MathOperation addDel = Add;
            MathOperation subtractDel = Subtract;
            MathOperation multiplyDel = Multiply;
            MathOperation divideDel = Divide;

            PerformOperation(5, 3, addDel);
            PerformOperation(5, 3, subtractDel);
            PerformOperation(5, 3, multiplyDel);
            PerformOperation(5, 3, divideDel);

            MathOperation powerDelegate = delegate (double x, double y)
            {
                return Math.Pow(x, y);
            };

            PerformOperation(2, 3, powerDelegate);

            MathOperation squareRootDelegate = (x, y) => Math.Pow(x, 1 / y);

            PerformOperation(4, 2, squareRootDelegate);

            MathOperation Del = addDel + subtractDel + multiplyDel;

            PerformOperation(5, 2, Del);
            Console.ReadKey();  
        }
    }
}
