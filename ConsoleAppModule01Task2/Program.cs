using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppModule01Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Count: ");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                int[] nums = new int[n]; 

                for (int i = 0; i < n; i++)
                {
                    if (int.TryParse(Console.ReadLine(), out int num))
                    {
                        nums[i] = num;
                    }
                }

                int sum = 0;
                for (int i = 0; i < n; i++)
                {
                    sum += nums[i];
                }
                Console.WriteLine($"Summa: {sum}");
                Console.ReadKey();
            }
        }
    }
}
