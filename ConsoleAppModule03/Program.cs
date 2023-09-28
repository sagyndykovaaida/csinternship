using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppModule03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "123 45 678 94 324 7893 12";
            string[] words = input.Split(' ');

            int sum = 0;

            foreach (string word in words)
            {
                if (word.EndsWith("3") || word.EndsWith("4"))
                {
                    if (int.TryParse(word, out int number))
                    {
                        sum += number;
                    }
                }
            }

            Console.WriteLine("Сумма чисел, оканчивающихся на 3 или 4: " + sum);
            Console.ReadLine();
        }
    }
}
