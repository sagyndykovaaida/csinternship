using System;

namespace ConsoleAppModule08
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("начальное значение диапазона: ");
            int start = int.Parse(Console.ReadLine());

            Console.Write("конечное значение диапазона: ");
            int end = int.Parse(Console.ReadLine());

            RangeOfArray range = new RangeOfArray();
            int[] arr = range[start, end];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }

            Console.ReadKey();
        }
    }

    public class RangeOfArray
    {
        private int[] arr = new int[5] { 1, 2, 3, 4, 5 };

        public int[] this[int start, int end]
        {
            get
            {
                if (start > end)
                {
                    Console.WriteLine("Ошибка");
                }

                int n = end - start + 1;
                int[] result = new int[n];

                for (int i = 0, j = start; i < n; i++, j++)
                {
                    result[i] = arr[j];
                }

                return result;
            }
        }
    }
}
