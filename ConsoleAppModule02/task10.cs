using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppModule02
{
    internal class task10
    {
        static void Main(string[] args)
        {
            int day = int.Parse(Console.ReadLine());

            string dayName = GetDayName(day);

            if (dayName != null)
            {
                Console.WriteLine(day + " - " + dayName);
            }
            Console.ReadKey();
        }

        static string GetDayName(int day)
        {
            switch (day)
            {
                case 1:
                    return "понедельник";
                case 2:
                    return "вторник";
                case 3:
                    return "среда";
                case 4:
                    return "четверг";
                case 5:
                    return "пятница";
                case 6:
                    return "суббота";
                case 7:
                    return "воскресенье";
                default:
                    return null;
            }
        }
    }
}
