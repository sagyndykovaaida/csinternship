using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTaskModule08
{
    internal class task2
    {
        class UtilityBills
        {
            private double[] rates;
            private double[] discounts;
            private double[] charges;

            public UtilityBills()
            {
                rates = new double[4] { 145.0, 216.0, 38.0, 1000.0 };  
                discounts = new double[4] { 0.0, 0.0, 0.0, 0.0 };
                charges = new double[4]; 
            }

            public double this[int index]
            {
                get
                {
                    if (index >= 0 && index < 4)
                    {
                        return charges[index];
                    }
                    throw new IndexOutOfRangeException("ошибка ");
                }
            }

            public void CalculateCharges(double area, int residents, bool isWinter, bool hasDiscount, string  discountType)
            {
                double heatingRate = isWinter ? 145.0 : 135.0;
                double waterRate = 216.0;
                double gasRate = 38.0;
                double repairRate = 1000.0;

                if (hasDiscount)
                {
                    if (discountType == "1")
                    {
                        discounts[0] = 0.3;
                        discounts[1] = 0.3;
                        discounts[2] = 0.3;
                        discounts[3] = 0.3;
                    }
                    else if (discountType == "2")
                    {
                        discounts[0] = 0.5;
                        discounts[1] = 0.5;
                        discounts[2] = 0.5;
                        discounts[3] = 0.5;
                    }
                }

                charges[0] = heatingRate * area - (heatingRate * area * discounts[0]);
                charges[1] = waterRate * residents - (waterRate * residents * discounts[1]);
                charges[2] = gasRate * residents - (gasRate * residents * discounts[2]);
                charges[3] = repairRate * area - (repairRate * area * discounts[3]);
            }
        }

        static void Main()
        {
            UtilityBills utilityBills = new UtilityBills();

            Console.Write("Введите площадь помещения (м2): ");
            double area = double.Parse(Console.ReadLine());

            Console.Write("Введите количество проживающих людей: ");
            int residents = int.Parse(Console.ReadLine());

            Console.Write("Сезон (осень/зима): ");
            string season = Console.ReadLine().ToLower();

            Console.Write("Наличие льгот (да/нет): ");
            string hasDiscountStr = Console.ReadLine().ToLower();

            bool isWinter = season == "зима";
            bool hasDiscount = hasDiscountStr == "да";
            string discountType = hasDiscount ? GetDiscountType() : "";

            utilityBills.CalculateCharges(area, residents, isWinter, hasDiscount, discountType);

            Console.WriteLine("Вид платежа      | Начислено (руб)          | Льготная скидка (%)                  | Итого");
            Console.WriteLine($"Отопление       | {utilityBills[0],16}  | {utilityBills[0] / area,20}        | {utilityBills[0],11}");
            Console.WriteLine($"Вода            | {utilityBills[1],16}  | {utilityBills[1] / residents,20}   | {utilityBills[1],11}");
            Console.WriteLine($"Газ             | {utilityBills[2],16}  | {utilityBills[2] / residents,20}   | {utilityBills[2],11}");
            Console.WriteLine($"Ремонт          | {utilityBills[3],16}  | {utilityBills[3] / area,20}        | {utilityBills[3],11}");
            double totalCharges = utilityBills[0] + utilityBills[1] + utilityBills[2] + utilityBills[3];
            Console.WriteLine($"Итого           | {totalCharges,16}");

            Console.ReadKey();
        }

        static string GetDiscountType()
        {
            Console.Write("Введите статус (ветеран труда (1)/ветеран войны(2)): ");
            return Console.ReadLine().ToLower();
        }
    }
}
