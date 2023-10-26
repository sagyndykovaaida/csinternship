using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppModule08
{
    internal class practice2
    {
        static void Main()
        {
            DiscountCalc discountSchedule = new DiscountCalc();

            DateTime currentTime = DateTime.Now;

            double discount = discountSchedule[currentTime.Hour];


            double totalCost = 0.0;

            Console.Write("количество продуктов: ");
            int numberOfProducts = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfProducts; i++)
            {
                Console.Write($"название продукта {i}: ");
                string productName = Console.ReadLine();

                Console.Write($"ценa продукта {i}: ");
                double productPrice = double.Parse(Console.ReadLine());

                totalCost += productPrice;
            }

            if (discount > 0)
            {
                Console.WriteLine("Скидка 5% предоставляется с 8:00 до 12:00");
            }
            else
            {
                Console.WriteLine("Скидка не предоставляется.");
            }

            if (discount > 0)
            {
                totalCost *= (1 - discount);
            }

            Console.WriteLine($"Общая сумма: {totalCost}");

            Console.ReadKey();
        }
    }

    class DiscountCalc
    {
        private double[] discnts = new double[24];

        public DiscountCalc()
        {
            for (int i = 8; i < 12; i++)
            {
                discnts[i] = 0.05;
            }
        }

        public double this[int hour]
        {
            get
            {
                if (hour >= 0 && hour < 24)
                {
                    return discnts[hour];
                }
                return 0;
            }
        }
    }
}
