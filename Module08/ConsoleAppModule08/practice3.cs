using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppModule08
{
    internal class practice3
    {
        static void Main()
        {
            Sales salesData = new Sales();

            salesData[1] = 100;
            salesData[2] = 150;
            salesData[3] = 200;
            salesData[4] = 250;
            salesData[5] = 300;

            double[] forecast = salesData.SalesForecast();

            Console.WriteLine("продаж на следующие 3 месяца:");
            for (int i = 0; i < forecast.Length; i++)
            {
                Console.WriteLine($"Месяц {i + 6}: {forecast[i]}");
            }

            Console.ReadKey();
        }
        class Sales
        {
            private double[] sales = new double[5]; 

            public double this[int month]
            {
                get
                {
                    if (month >= 1 && month <= 5)
                    {
                        return sales[month - 1];
                    }
                    return 0; 
                }
                set
                {
                    if (month >= 1 && month <= 5)
                    {
                        sales[month - 1] = value;
                    }
                }
            }

            public double calcAverage()
            {
                double sum = 0;

                for (int i = 0; i < 5; i++)
                {
                    sum += sales[i];
                }

                return sum / 5;
            }

            public double[] SalesForecast()
            {
                double averageSales = calcAverage();
                double[] forecast = new double[3];

                for (int i = 0; i < 3; i++)
                {
                    forecast[i] = averageSales;
                }

                return forecast;
            }
        }
    }
}
