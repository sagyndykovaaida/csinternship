using Module13.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module13.ConsoleApp
{
    internal class BankQueue
    {
        static void Main()
        {
            Bank bank = new Bank();

            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Встать в очередь");
                Console.WriteLine("2. Вызвать следующего клиента");
                Console.WriteLine("3. Выйти");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Введите свое имя:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Выберите тип обслуживания (Кредитование, Открытие вклада, Консультация):");
                        string serviceType = Console.ReadLine();
                        bank.AddClient(name, serviceType);
                        break;
                    case "2":
                        bank.ServeNextClient();
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
                Console.ReadKey();
            }
           
        }
    }
}
