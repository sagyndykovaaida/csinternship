using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppModule05
{
    internal class task2
    {
        static void Main()
        {
            int[] array = { 1, 2, 3, 4, 5 };

            try
            {
                for (int i = 0; i <= array.Length; i++)
                {
                    Console.WriteLine(array[i]);
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("final");
            }
            Console.ReadKey();
        }
    }
}
