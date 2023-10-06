using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppModule05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                int result = DivideNumbers(a, b);
                Console.WriteLine("Результат деления: " + result);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
            Console.ReadKey();  
        }


        public static int DivideNumbers(int a, int b)
        {
            if (b == 0)
            {
                
                throw new DivideByZeroException("Деление на ноль недопустимо");
            }

            return a / b;
        }
    }
}
