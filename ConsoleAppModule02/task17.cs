using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppModule02
{
    internal class task17
    {
        static void Main()
        {
            bool x = false;
            bool y = true;
            bool z = false;

            bool resultA = x || z;
            bool resultB = x && y;
            bool resultC = x && z;

            Console.WriteLine("X или Z: " + resultA);
            Console.WriteLine("X и Y: " + resultB);
            Console.WriteLine("X и Z: " + resultC);

        }
    }
}
