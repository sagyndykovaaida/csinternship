using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppModule08
{
    internal class MarketProgram
    {
        static void Main(string[] args)
        {
            Supermaket supermarket = new Supermaket();
            Console.WriteLine("Сумм всех продуктов: {0}",
                supermarket[1]);

            Console.ReadKey();
        }
    }

}
