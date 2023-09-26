﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppModule02
{
    internal class task11
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            int sum = 0;
            int temp = number;
            while (temp > 0)
            {
                int n = temp % 10;
                sum += n;
                temp /= 10;
            }

            int product = 1;
            temp = number;
            while (temp > 0)
            {
                int digit = temp % 10;
                product *= digit;
                temp /= 10;
            }

            int count = 0;
            temp = number;
            while (temp > 0)
            {
                count++;
                temp /= 10;
            }

            bool isFourDigit = number >= 1000 && number <= 9999;
            int first = number % 10;
            int last = number % 10;
            string result = first > last ? "first" : "last";

            Console.WriteLine($"a. Сумма цифр больше 10: {sum > 10}");
            Console.WriteLine($"b. Произведение цифр меньше 50: {product < 50}");
            Console.WriteLine($"c. Количество цифр четное: {count % 2 == 0}");
            Console.WriteLine($"d. Четырехзначное число: {isFourDigit}");
            Console.WriteLine($"e. Первая цифра не превышает 6: {first <= 6}");
            Console.WriteLine($"f. Начинается и заканчивается одной и той же цифрой: {first == last}");
            Console.WriteLine($"g. Большая цифра: {result}");

            Console.ReadKey();
        }
    }
}
