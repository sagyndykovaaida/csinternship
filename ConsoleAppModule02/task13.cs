﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppModule02
{
    internal class task13
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            const int funt = 543;
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"{i} funt = {i * funt} g");
            }
            Console.ReadKey();
        }
    }
}
