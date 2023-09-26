using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppModule02
{
    internal class task20
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            if (number % 2 == 0)
            {
                Console.WriteLine("четный");
            }
            else if (number % 10 == 7)
            {
                Console.WriteLine("оканчивается цифрой 7");
            }
            else
            {
                Console.WriteLine("error");
            }
            Console.ReadKey();
        }
    }
}
