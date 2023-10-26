using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTaskModule08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SquaredArray squaredArray = new SquaredArray(1, 2, 3, 4, 5);


            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(squaredArray[i]);
            }

            Console.ReadKey();
        }
    }

    class SquaredArray
    {
        private double[] array;

        public SquaredArray(params double[] values)
        {
            array = new double[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                array[i] = values[i] * values[i];
            }
        }

        public double this[int index]
        {
            get
            {
                if (index >= 0 && index < array.Length)
                {
                    return array[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("ошибка");
                }
            }
            set
            {
                if (index >= 0 && index < array.Length)
                {
                    array[index] = value * value;
                }
                else
                {
                    throw new IndexOutOfRangeException("ошибка");
                }
            }
        }
    }
}
